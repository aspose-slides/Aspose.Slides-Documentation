---
title: Aspose.Slides for .NET'i Docker'da Çalıştır
linktitle: Docker
type: docs
weight: 140
url: /tr/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker konteyneri
- çok aşamalı yapı
- konteyner imajı
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- yazı tipleri
- PDF dönüşümü
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Resmi .NET görüntülerinde çok aşamalı bir Dockerfile ile Docker'da Aspose.Slides for .NET konsol uygulamasını oluşturun ve çalıştırın; ihtiyaç duyduğu Linux kütüphaneleri ve yazı tipleri, ve oluşturulan dosyaları makinenize nasıl kopyalayacağınız."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET’in bir Docker konteynerinde nasıl çalıştırılacağını gösterir. Bir metin kutusu içeren bir sunum oluşturup PDF’ye dönüştüren küçük bir konsol uygulaması oluşturursunuz, Microsoft’un resmi .NET görüntülerinde çok aşamalı bir Dockerfile ile paketlersiniz, çalıştırırsınız ve oluşturulan dosyaları makinenize kopyalarsınız. Makale ayrıca konteynerde Aspose.Slides’in ihtiyaç duyduğu Linux kütüphanelerini ve yazı tiplerini listeler ve Alpine Linux için bir varyantla sona erer.

Makinenizde sadece Docker gerekir. .NET SDK, oluşturma görüntüsünün bir parçasıdır, bu yüzden ayrı olarak kurmanıza gerek yoktur. Docker kurmak için [Docker'ı Edinin](https://docs.docker.com/get-started/get-docker/).

## **Paketi ve Temel Görüntüyü Seçin**

Varsayılan .NET 10 konteyner görüntüleri Ubuntu 24.04 temellidir. Bu görüntülerde [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) paketini kullanın. `fontconfig` kütüphanesini gerektirir ve .NET çalışma zamanı görüntüsü ne bu kütüphaneyi ne de herhangi bir yazı tipini içerdiği için bu makaledeki Dockerfile her ikisini de kurar.

Aspose.Slides.NET6.CrossPlatform Alpine Linux’ta çalışmaz. Alpine tabanlı görüntüler için [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) paketini `libgdiplus` ile birlikte kullanın; ayrıntılar **Alpine Linux'ta Çalıştır** bölümünde açıklanmıştır. [Kurulum](/slides/tr/net/installation/) iki paketi karşılaştırır.

## **Projeyi Oluşturun**

*HelloSlidesDocker* adında bir klasör oluşturun ve aşağıdaki üç dosyayı içine ekleyin.

*HelloSlidesDocker.csproj* .NET 10 için bir konsol uygulamasını, aşağıda kullanılan konteyner görüntü sürümünü ve Aspose.Slides.NET6.CrossPlatform başvurusunu tanımlar. Paket sürümünü [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) üzerinde listelenen en yeni sürüme ayarlayın.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturur, ilk slaytına metin içeren bir dikdörtgen ekler ve sunumu iki kez [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) yöntemiyle kaydeder: PPTX ve PDF olarak. Her iki dosya da çalışma dizini altındaki *output* klasörüne gider. Uygulama ardından PDF oluşturulurken değiştirilen yazı tiplerini [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) ile listeler; böylece konteynerin sunumun kullandığı yazı tiplerine sahip olup olmadığını görebilirsiniz.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* yerel bir derlemenin *bin* ve *obj* klasörlerini ve önceki çalıştırmaların çıktısını Docker derleme bağlamından dışarı tutar, böylece imaj yalnızca kaynak dosyalardan oluşturulur.

```text
bin/
obj/
output/
```

## **Dockerfile'ı Yazın**

Aynı klasöre *Dockerfile* adında bir dosya ekleyin:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

Dosya iki aşamadan oluşur:

- **Derleme aşaması** .NET SDK görüntüsünden başlar. Proje dosyasını kopyalar ve önce NuGet paketlerini geri yükler, böylece proje dosyası değişmediği sürece Docker bu katmanı yeniden kullanır. Ardından kaynak kodunu kopyalar ve uygulamayı */app* konumuna yayımlar.
- **Çalışma zamanı aşaması** daha küçük .NET çalışma zamanı görüntüsünden başlar; bu görüntüde SDK yoktur ve yalnızca yayımlanan uygulamayı kopyalar. İki paket kurar:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform başlatıldığında bu kütüphaneyi yükler. Olmazsa uygulama `DllNotFoundException` ile `libfontconfig.so.1` hatası verir.
  - `fonts-dejavu-core`: çalışma zamanı görüntüsü yazı tipi içermez ve Aspose.Slides en az bir yüklü yazı tipine ihtiyaç duyar; yoksa dönüşüm `InvalidOperationException: Cannot find any fonts installed on the system.` hatasıyla durur. Yüklü olmayan yazı tipindeki metin, bir yedek yazı tipiyle çizilir. DejaVu yazı tipleri, metnin çizilmesini sağlayan küçük bir settir; sunumları tasarlandıkları yazı tipleriyle çizmek için [Yazı Tiplerini Dağıt](/slides/tr/net/deploy-fonts/) bölümüne bakın.

  `--no-install-recommends` ve paket listelerinin kaldırılması imajı küçük tutar. Son satırlar *output* klasörünü oluşturur, resmi .NET görüntülerinin tanımladığı `app` (kök olmayan) kullanıcısına (kullanıcı kimliği `APP_UID` değişkeninde) verir ve uygulamayı bu kullanıcıyla çalıştırır.

ASP.NET Core uygulaması için çalışma zamanı aşamasını `mcr.microsoft.com/dotnet/aspnet:10.0` görüntüsünden başlatın. Aynı Ubuntu görüntüsü temel alındığından aynı paketler gerekir.

## **Konteyneri Oluşturun ve Çalıştırın**

*HelloSlidesDocker* klasöründe bir terminal açın. İmajı oluşturun, ardından bir konteyner çalıştırın:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

İlk oluşturma temel görüntüleri ve NuGet paketlerini indirir, bu yüzden sonraki oluşturmalardan daha uzun sürer. Konteyner uygulamayı çalıştırır ve durur. Şu çıktıyı verir:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

İlk satır, metnin yeni bir sunumun varsayılan yazı tipi olan Calibri kullandığını ve Calibri’nin imajda yüklü olmadığını, bu yüzden Aspose.Slides’in metni DejaVu Sans ile çizdiğini gösterir. PDF’deki metin gerçek, seçilebilir bir metindir. Lisansınız yoksa Aspose.Slides, kaydettiği her slayta bir değerlendirme filigranı ekler; ayrıntılar için [Lisanslama](/slides/tr/net/licensing/) bölümüne bakın.

## **Çıktıyı Makinenize Kopyalayın**

Dosyalar durdurulmuş konteynerin */app/output* klasöründedir. Bunları makinenizde bir *output* klasörüne kopyalayın, ardından konteyneri kaldırın:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Bu iki komut Bash, PowerShell ve Windows Komut İstemi’nde aynı şekilde çalışır.

Linux’ta, bir klasörü konteyner içine bağlayarak uygulamanın dosyaları doğrudan oraya yazmasını sağlayabilirsiniz:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user` seçeneği uygulamayı sizin kullanıcı ve grup kimliklerinizle çalıştırır, böylece oluşturduğunuz klasöre yazabilir ve dosyalar size ait olur. `--rm` konteyner durduğunda onu kaldırır.

## **Alpine Linux'ta Çalıştır**

Uygulamayı Alpine tabanlı bir görüntüde çalıştırmak için Aspose.Slides.NET paketine geçin ve çalışma zamanı aşamasını değiştirin. Derleme aşaması aynı kalır.

1. *HelloSlidesDocker.csproj* dosyasında paket referansını şu şekilde değiştirin:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. *Program.cs* dosyasında ilk Aspose.Slides çağrısından önce, `using` yönergelerinden sonra şu ifadeyi ekleyin. Bu, Aspose.Slides.NET’in Linux için kullandığı System.Drawing desteğini etkinleştirir:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. *Dockerfile* içinde çalışma zamanı aşamasını (ikinci `FROM` satırından itibaren) şu içerikle değiştirin:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

Alpine aşaması üç paket kurar ve bir ayarı değiştirir:

- `libgdiplus`: Aspose.Slides.NET’in Linux’taki grafik kütüphanesidir.
- `font-dejavu`: yazı tiplerini sağlar. Hiç yazı tipi yoksa dönüşüm `System.ArgumentException: Font '?' cannot be found` hatasıyla durur.
- `icu-libs` ve `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false`: kültür verilerini sağlar. Alpine .NET görüntüleri varsayılan olarak küresel olmayan (invariant) moda çalışır; bu modda Aspose.Slides `CultureNotFoundException` ile `en-US` kültürünü bulamaz.

Yukarıdaki aynı komutlarla oluşturun, çalıştırın ve çıktıyı kopyalayın. Bu imajda uygulama yalnızca `Saved` satırını yazdırır: Linux’ta Aspose.Slides.NET ile fontconfig eksik bir yazı tipi için yedek seçer ve [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) bunu listelemez. [Yazı Tiplerini Dağıt](/slides/tr/net/deploy-fonts/) hangi yazı tipinin kullanıldığını nasıl kontrol edeceğinizi gösterir.

## **SSS**

**Uygulama “Unable to load shared library 'libaspose.slides.drawing.capi…'” hatasıyla duruyor. Ne eksik?**

Ubuntu ve Debian görüntülerinde `libfontconfig1` paketi eksiktir; hata mesajı açılamayan dosya olarak `libfontconfig.so.1` listesini gösterir. Alpine Linux’ta bu mesaj, Aspose.Slides.NET6.CrossPlatform’un kullanıldığını gösterir; **Alpine Linux'ta Çalıştır** bölümünde anlatıldığı gibi Aspose.Slides.NET paketine geçin.

**PDF’deki metin PowerPoint’teki metinden farklı bir yazı tipinde neden?**

Sunumun kullandığı yazı tipleri imajda yüklü değildir, bu yüzden Aspose.Slides metni bir yedek yazı tipiyle çizer. Uygulamanın çıktısı her değiştirilmiş yazı tipini adlandırır. Yazı tiplerini imaja kurmak veya uygulama klasöründen yüklemek için [Yazı Tiplerini Dağıt](/slides/tr/net/deploy-fonts/) bölümüne bakın.

**Makinemde .NET SDK’a ihtiyacım var mı?**

Hayır. Derleme aşaması uygulamayı SDK görüntüsü içinde derler. SDK’ya yalnızca uygulamayı Docker dışından da derlemek ve çalıştırmak istiyorsanız gerek duyarsınız; detaylar için [Kurulum](/slides/tr/net/installation/) bölümüne bakın.