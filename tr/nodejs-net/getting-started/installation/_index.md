---
title: Kurulum
type: docs
weight: 70
url: /tr/nodejs-net/installation/
keywords:
- Aspose.Slides'ı indir
- Aspose.Slides'ı kur
- Aspose.Slides kurulumu
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Windows veya Linux üzerinde npm üzerinden .NET aracılığıyla Aspose.Slides for Node.js'i kurun: önkoşullar, edge-js geçersiz kılması, bir kez yapılan NuGet geri yüklemesi ve bir sunum oluşturan ilk program."
---
## **Genel Bakış**

Aspose.Slides for Node.js via .NET, npm paketi `aspose.slides.via.net`'dir. Aspose.Slides .NET kütüphanesini Node.js içinde [edge-js](https://github.com/agracio/edge-js) köprüsü aracılığıyla çalıştırır, bu nedenle çalışan bir kurulum hem Node.js hem de .NET gerektirir.

Bu makale, temiz bir makineden bir sunum oluşturan ilk programa kadar sizi götürür. Dört adım vardır: edge-js geçersiz kılmasını (override) içeren bir proje oluşturun, paketi npm'den yükleyin, paketin .NET bağımlılıklarını bir kez geri yükleyin ve betiğinizi proje klasöründen çalıştırın.

## **Gereksinimler**

- **Node.js 22 veya 24 LTS**, x64 sürümü, [nodejs.org](https://nodejs.org/en/download) adresinden.
- **.NET SDK 8 veya daha yeni sürüm**, [dotnet.microsoft.com](https://dotnet.microsoft.com/download) adresinden. Sadece .NET çalışma zamanı yeterli değildir: aşağıdaki geri yükleme adımı SDK'ya ve betiğiniz çalıştığında köprüye de ihtiyaç duyar. Yüklü SDK'ları kontrol etmek için `dotnet --list-sdks` komutunu çalıştırın.
- **Yalnızca Linux'ta**:
  - npm, Linux'ta kurulum sırasında edge-js'i derlediği için `python3`, `make` ve `g++` yapı araçları;
  - Aspose.Slides yerel çizim kütüphanesinin yüklediği fontconfig kütüphanesi.

  Debian'da bu paketler `python3`, `make`, `g++` ve `libfontconfig1`'dir.

Bu makaledeki adımlar şu platformlarda test edilmiştir:

| Platform | Sonuç |
|---|---|
| Windows x64, Node.js 22 veya 24 | Çalışıyor. Microsoft Visual C++ Redistributable yüklü olarak test edildi. |
| Linux x64, Node.js 22 veya 24, sistem OpenSSL'i Node.js'e dahil edilen OpenSSL ile aynı sürüm hattına ait, örneğin Debian 13 | Çalışıyor. |
| Linux, iki OpenSSL sürümü farklı olduğunda, örneğin Debian 12 | Node.js, bir sunum oluşturulduğunda segmantasyon hatasıyla çöküyor. |
| macOS | Doğrulanmadı. |

Linux'ta, başlamadan önce iki sürümü karşılaştırın. İlk komut Node.js'e dahil edilen OpenSSL sürümünü, ikincisi sistem sürümünü gösterir. Her iki sürümün de aynı ana ve alt sürüm numaralarıyla başladığı bir sistem kullanın, örneğin `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

`openssl` komutu bulunamazsa, önce `openssl` paketini yükleyin.

## **Proje Oluşturma**

Projeniz için bir klasör oluşturun, başlatın ve npm'in hangi edge-js sürümünü yükleyeceğini söyleyen bir geçersiz kılma ekleyin:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

Paket, önceden derlenmiş Windows ikili dosyaları Node.js 20'ye kadar duran eski bir edge-js sürümü talep eder; bu nedenle geçersiz kılma olmadan Windows'ta ilk betik "The edge module has not been pre-compiled for node.js version" hatasıyla durur. Komut, `overrides` bölümünü `package.json`'a yazar; paketi yüklemeden önce ekleyin.

## **Paketi Yükleme**

Aspose.Slides for Node.js via .NET paketini npm'den yükleyin:

```sh
npm install aspose.slides.via.net
```

Kurulum sırasında paket, yerel çizim kütüphanelerini (adında `aspose.slides.drawing.capi` geçen dosyalar) `package.json` dosyasının yanına, proje klasörüne kopyalar.

Paket ayrıca [releases.aspose.com](https://releases.aspose.com/slides/nodejs-net/) adresinde bir ZIP arşivi olarak da yayınlanır. Bu makale sadece npm üzerinden kurulumu kapsar.

## **.NET Bağımlılıklarını Geri Yükleme**

Paket, Aspose.Slides .NET derlemelerini içerir, ancak bu derlemelerin bağımlı olduğu 20 NuGet paketini içermez. Çalışma zamanında .NET, bunları NuGet paket önbelleğinde arar: Windows'ta `%USERPROFILE%\.nuget\packages`, Linux'ta `~/.nuget/packages` veya `NUGET_PACKAGES` ortam değişkeninde ayarlı klasör. Eksikse, ilk betik "assembly specified in the dependencies manifest was not found" hatasıyla durur.

Önbelleği doldurmak için proje klasöründe `deps` adlı bir klasör oluşturun ve aşağıdaki dosyayı içinde `deps.csproj` adıyla kaydedin. Her `PackageDownload` öğesi, köşeli parantez içindeki tam sürümde bir paketi indirir; hiçbir şey derlenmez.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

Ardından proje klasöründen geri yükleyin:

```sh
dotnet restore deps/deps.csproj
```

Bu adımı makine başına bir kez yapmanız yeterlidir; paketler NuGet önbelleğinde kalır ve aynı makinedeki sonraki projeler onları kullanır. Geri yüklemeden sonra `deps` klasörünü silebilirsiniz.

## **İlk Programı Çalıştırma**

Proje klasöründe aşağıdaki kodla `hello.js` adlı bir dosya oluşturun. Bir sunum oluşturur, ilk slayta "Hello, World!" metniyle bir dikdörtgen ekler ve sonucu `hello.pptx` olarak kaydeder:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Yeni bir sunum bir boş slayt içerir.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Pozisyon ve boyut noktalar (1/72 inç) cinsindedir: x, y, genişlik, yükseklik.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Sunumu destekleyen .NET nesnesini serbest bırak.
    presentation.dispose();
}
```

Proje klasöründen çalıştırın:

```sh
node hello.js
```

Betik `Saved hello.pptx` mesajını verir. `hello.pptx` dosyasını açtığınızda metni içeren dolu bir dikdörtgenle tek bir slayt görürsünüz. Lisans olmadan Aspose.Slides bir değerlendirme filigranı ekler; bkz. [Evaluate Aspose.Slides](/slides/tr/nodejs-net/evaluate-aspose-slides/) ve [Licensing](/slides/tr/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Betiklerinizi `package.json` dosyasını içeren proje klasöründen çalıştırın. `hello.pptx` gibi göreli yollar geçerli klasöre göre çözülür; bazı makinelerde başka bir klasörden başlatılan betik bir sunum oluşturamaz.
{{% /alert %}}

JavaScript API'si Aspose.Slides for .NET'i yansıtır: sınıflar .NET adlarını korur, özellikler ve yöntemler camelCase kullanır (`Slides` → `slides`, `AddAutoShape` → `addAutoShape`) ve koleksiyon öğeleri `get(index)` ile okunur. Bu paket için ayrı bir API referansı yoktur; sınıf ve üye detayları için [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) adresini kullanın; örnek: [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ve [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/).

## **SSS**

**"The edge module has not been pre-compiled for node.js version" ne anlama geliyor?**

npm, paket tarafından istenen eski edge-js sürümünü yükledi. [Proje Oluşturma](#proje-oluşturma) bölümündeki geçersiz kılmayı ekleyin ve `npm install` komutunu tekrar çalıştırın.

**"assembly specified in the dependencies manifest was not found" ne anlama geliyor?**

.NET bağımlılıkları NuGet önbelleğinde yok. Aynı çalıştırma aynı zamanda "edge.initializeClrFunc is not a function" hatasını da verir. [ .NET Bağımlılıklarını Geri Yükleme](#net-bağımlılıklarını-geri-yükleme) adımını bir kez izleyin, ardından betiğinizi tekrar çalıştırın.

**Linux'ta "The edge native module is not available" hatası ne anlama geliyor?**

`npm install` sırasında edge-js derlenmemiştir; örneğin `python3`, `make` veya `g++` eksik olduğunda. npm bunu hata olarak raporlamaz. Derleme araçlarını yükleyin, ardından proje klasöründe `npm rebuild edge-js` komutunu çalıştırın.

**Boş "Error" mesajıyla sunum oluşturma neden başarısız oluyor?**

Linux'ta fontconfig kütüphanesinin kurulu olduğunu kontrol edin (`libfontconfig1` Debian'da). Olmazsa yerel çizim kütüphanesi yüklenemez. Her sistemde betiği proje klasöründen çalıştırdığınızdan emin olun.

**Linux'ta Node.js segmantasyon hatasıyla neden çöküyor?**

Sistem OpenSSL'i ve Node.js'e dahil edilen OpenSSL farklı sürüm hatlarından gelmektedir. Bunları [Gereksinimler](#gereksinimler) bölümünde gösterildiği gibi karşılaştırın ve eşleşen bir dağıtım veya Node.js yapısı kullanın.

**Her proje için NuGet geri yüklemesini tekrarlamam gerekir mi?**

Hayır. Geri yükleme, kullanıcı hesabınız için NuGet önbelleğini doldurur ve aynı makinedeki her proje aynı önbelleği kullanır.