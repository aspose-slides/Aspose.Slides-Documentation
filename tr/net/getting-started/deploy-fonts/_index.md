---
title: Linux ve Docker'da Aspose.Slides için Yazı Tipi Dağıtımı
linktitle: Yazı Tipi Dağıtımı
type: docs
weight: 145
url: /tr/net/deploy-fonts/
keywords:
- yazı tiplerini dağıt
- yazı tiplerini kur
- Docker'da yazı tipleri
- Linux'ta yazı tipleri
- eksik yazı tipleri
- yazı tipi yedekleme
- Microsoft temel yazı tipleri
- ttf-mscorefonts-installer
- özel yazı tipleri
- varsayılan yazı tipi
- sunucu
- konteyner
- PDF dönüşümü
- sunum
- .NET
- C#
- Aspose.Slides
description: "Linux sunucularında ve Docker konteynerlerinde Aspose.Slides for .NET için yazı tiplerini dağıtın: hangi yazı tiplerinin yedeklendiğini kontrol edin, Debian, Ubuntu ve Alpine'de yazı tipi paketlerini kurun, kendi yazı tipi dosyalarınızı ekleyin ve varsayılan bir yazı tipi ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumu oluştururken kullanılabilir yazı tipleriyle metni çizer; örneğin slaytları PDF’ye veya görüntülere dönüştürürken. Windows masaüstü bilgisayarları genellikle sunumların kullandığı yazı tiplerine sahiptir. Linux sunucuları ve konteynerları ise genellikle çok az ya da hiç yazı tipi içermez; bu nedenle Aspose.Slides metni bir yedek yazı tipiyle çizer. Yedek yazı tipinin harf şekilleri ve genişlikleri farklıdır; bu yüzden satırlar farklı kayabilir, metin şeklinin dışına taşabilir ve yedekte bulunmayan karakterler doğru çizilemez. Hiç yazı tipi yüklü değilse dönüşüm bir hatayla durur.

Bu makale, Aspose.Slides’in hangi yazı tiplerini yedeklediğini nasıl kontrol edeceğinizi, Debian, Ubuntu ve Alpine Linux’ta yazı tiplerini nasıl kuracağınızı, kendi yazı tipi dosyalarınızı nasıl ekleyeceğinizi ve eksik bir yazı tipi olduğunda hangi yazı tipinin kullanılacağını nasıl ayarlayacağınızı gösterir. Örnekler, resmi .NET görüntülerinde Docker’da çalıştırılır; bkz. [Run Aspose.Slides for .NET in Docker](/slides/tr/net/how-to-run-aspose-slides-in-docker/). Paket komutları Dockerfile talimatlarıdır; bir Linux sunucusunda aynı komutları root olarak çalıştırın.

Yazı tipi API’si hakkında, örneğin bir sunuma yazı tipi gömmek ve yedekleme ve değiştirme kuralları, bkz. [PowerPoint Fonts](/slides/tr/net/powerpoint-fonts/).

## **Hangi Yazı Tiplerinin Yedeklendiğini Kontrol Edin**

Aşağıdaki konsol uygulaması, mevcut ortamda Aspose.Slides’in yedeklediği yazı tiplerini raporlar. *FontCheck* adlı bir klasör oluşturun ve aşağıdaki dosyaları içine ekleyin.

*FontCheck.csproj* [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) paketine başvurur; bu paket Debian ve Ubuntu için hazırlanmıştır. Ayrıca isteğe bağlı bir *fonts* klasörünün dosyalarını uygulama çıktısına kopyalar; [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) bölümü bunu kullanır.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* bir slayta her yazı tipi adı için bir metin kutusu ekler ve yazı tipini [LatinFont](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/latinfont/) özelliğiyle atar. Yazı tipi adları komut satırından alınır; argüman verilmezse uygulama Calibri, Arial ve Times New Roman’ı kontrol eder. Aspose.Slides’in yazı tiplerini aradığı klasörleri ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)) yazdırır, slaytı *output/fonts.pdf* dosyasına render eder ve [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) tarafından raporlanan yedeklemeleri basar. Başlangıçtaki iki isteğe bağlı adım, *fonts* klasörünü yükleme ve bir `DEFAULT_FONT` değişkeni okuma, bu makalenin ilerleyen bölümlerinde açıklanmıştır.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// Kontrol edilecek yazı tipleri: komut satırı argümanları ya da üç yaygın Office yazı tipi.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Uygulamanın yanındaki fonts klasöründen yazı tipi dosyalarını yükle, eğer klasör mevcutsa.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Eksik bir yazı tipine sahip metinler için, ayarlanmışsa DEFAULT_FONT ortam değişkeninde belirtilen yazı tipini kullan.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* yerel derleme sonuçlarını derleme bağlamının dışına tutar:

```text
bin/
obj/
output/
```

*Dockerfile* uygulamayı .NET SDK görüntüsüyle derler ve .NET runtime görüntüsü üzerinde çalıştırır. Runtime aşaması, Aspose.Slides.NET6.CrossPlatform’un gerektirdiği `libfontconfig1` paketini ve DejaVu yazı tiplerini kurar. [Run Aspose.Slides for .NET in Docker](/slides/tr/net/how-to-run-aspose-slides-in-docker/) her talimatı açıklar.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

İmajı oluşturun ve kontrolü çalıştırın:

```bash
docker build -t font-check .
docker run --rm font-check
```

İmaj yalnızca DejaVu yazı tiplerini içerdiği için üç yazı tipinin de DejaVu Sans ile değiştirildiğini göreceksiniz:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Kendi sunumlarınızın yazı tiplerini kontrol etmek için, örneğin `docker run --rm font-check "Segoe UI" Consolas` gibi argümanlar geçirin. *output/fonts.pdf* dosyasını konteyner dışına kopyalamak için [Copy the Output to Your Machine](/slides/tr/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) bölümündeki komutları kullanın.

## **Debian ve Ubuntu’da Yazı Tipi Kurulumu**

### **Microsoft Core Fonts**

`ttf-mscorefonts-installer` paketi, web için Microsoft’un temel yazı tiplerini indirir ve kurar; bunlar arasında Arial, Times New Roman, Courier New, Verdana, Georgia ve Trebuchet MS bulunur. Yazı tipleri Microsoft’un son‑kullanıcı lisans sözleşmesine (EULA) tabidir ve paket yalnızca EULA kabul edildikten sonra kurulur. Docker derlemesi bu soruya yanıt veremez; bu yüzden yükleyici EULA’yı reddeder ve hiçbir yazı tipi kurmaz; `apt-get install` hâlâ başarı raporlar. Paketi kurmadan **önce** `debconf-set-selections` ile EULA’yı kabul edin.

*Dockerfile* içinde, runtime aşamasında paketleri kuran `RUN` talimatını aşağıdaki ile değiştirin:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

İmajı yeniden oluşturun ve aynı iki komutla kontrolü tekrar çalıştırın. Arial ve Times New Roman artık kurulu:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Aspose.Slides’in oluşturduğu bir sunumun varsayılan yazı tipi olan Calibri, temel yazı tipleri arasında yer almaz; bu yüzden hâlâ yedeklenir. Bkz. [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

Debian’da paket `contrib` depo bileşenindedir; Debian görüntüleri bunu etkinleştirmez; varsayılan .NET 8 ve .NET 9 görüntüleri Debian 12 tabanlıdır. Aynı talimat içinde `contrib`u etkinleştirin:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Ubuntu tabanlı .NET 10 görüntüleri zaten `multiverse` bileşenini etkinleştirir; bu bileşen paket içerir.

### **Diğer Yazı Tipi Paketleri**

Debian ve Ubuntu ayrıca özgür lisanslı yazı tipleri paketler; örnek:

| Paket | Yazı Tipleri |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif ve Mono; Arial, Times New Roman ve Courier New ile aynı metrikler |
| `fonts-crosextra-carlito` | Carlito; Calibri ile aynı metrikler |
| `fonts-crosextra-caladea` | Caladea; Cambria ile aynı metrikler |

Aynı `RUN` talimatında `apt-get install` ile kurun. Aspose.Slides.NET6.CrossPlatform, Linux yazı tipi yapılandırmasının takma adlarını uygulamaz: `fonts-liberation` kurulu olsa bile Arial metni hâlâ genel yedek yazı tipiyle çizilir, Liberation Sans ile değil. Eksik bir yazı tipi yerine metrik‑uyumlu bir yazı tipi kullanmak için onu [varsayılan yazı tipi](#set-a-default-font-for-missing-fonts) olarak ayarlayın veya bir [yazı tipi yedekleme kuralı](/slides/tr/net/font-substitution/) ekleyin.

## **Kendi Yazı Tipi Dosyalarınızı Ekleyin**

Dağıtımlarda paketlenmemiş yazı tipleri – örneğin kuruluşunuzun yazı tipleri veya sunucuda kullanma lisansına sahip olduğunuz diğer yazı tipleri – dosya olarak eklenebilir. Yazı tipi dosyalarını, örneğin *.ttf* dosyalarını, *FontCheck* klasörünün içinde *fonts* adlı bir klasöre koyun. Aşağıdaki örneklerde, Calibri ile aynı metriklere sahip bir yazı tipi olan Carlito’nun dosyaları kullanılmıştır; Carlito’yu [Google Fonts](https://fonts.google.com/specimen/Carlito) üzerinden indirebilirsiniz.

### **Yazı Tiplerini Sistem Yazı Tipi Klasörüne Kurun**

Aspose.Slides, `Font folders` satırında listelenen klasörlerdeki yazı tiplerini okur. Yazı tiplerinizi imajdaki tüm uygulamalar için kurmak istiyorsanız, bunları */usr/local/share/fonts* içine kopyalayın; bu klasör yerel olarak kurulan yazı tipleri içindir. Bu talimatı, paketleri kuran `RUN` satırından sonra runtime aşamasına ekleyin:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Yazı Tiplerini Uygulama Klasöründen Yükleyin**

Yazı tiplerini imaja kurmak yerine, uygulama ile birlikte dağıtabilir ve [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) ile yükleyebilirsiniz. Böylece yazı tipleri yalnızca Aspose.Slides tarafından kullanılır ve uygulama ile birlikte dağıtılır. *FontCheck* bunu yapar: *FontCheck.csproj* *fonts* klasörünü uygulama çıktısına kopyalar, *Program.cs* ise sunumu oluştururken `LoadExternalFonts` metoduna bu klasörü geçirir. [Custom Font](/slides/tr/net/custom-font/) diğer sağlama yöntemlerini açıklar; örneğin bellekten yükleme.

İmajı yeniden oluşturun, ardından Calibri ve Carlito’yu kontrol edin:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Uygulama klasörü artık yazı tipi klasörleri arasında görünecek ve Carlito artık yedeklenmeyecek:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Eksik Yazı Tipleri İçin Varsayılan Yazı Tipi Ayarlama**

Bir yazı tipi eksik olduğunda, Aspose.Slides kendi seçtiği bir yedek kullanır. Bunu kendiniz belirlemek için, [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) nesnesinin [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultregularfont/) özelliğini ayarlayın ve bu seçenekleri [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) kurucusuna iletin. *FontCheck* `DEFAULT_FONT` ortam değişkeninden yazı tipi adını okur. Carlito yüklüyse, eksik yazı tipleri için bunu kullanın:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri artık Carlito ile çizilir; karakterlerin genişlikleri Calibri ile aynı olduğu için metin satır sonlarını korur:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

Varsayılan yazı tipi her eksik yazı tipini değiştirir. Tek tek yazı tiplerini eşlemek için, örneğin Arial → Liberation Sans ve Calibri → Carlito, [yazı tipi yedekleme kurallarını](/slides/tr/net/font-substitution/) kullanın. Kurallar render edilen çıktıyı değiştirir, ancak `GetSubstitutions` bunları yansıtmaz; bu yüzden çıktıyı kontrol edin. Asya metinleri için ayrıca [DefaultAsianFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultasianfont/) ayarlayın; bkz. [Default Font](/slides/tr/net/default-font/).

## **Alpine Linux’da Yazı Tipi Kurulumu**

Alpine Linux’ta Aspose.Slides.NET paketini kullanın; [Run on Alpine Linux](/slides/tr/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) proje değişikliklerini listeler. *FontCheck*’i aynı değişikliklerle güncelleyin: paket referansını değiştirin, *Program.cs*’ye `SetSwitch` ifadesi ekleyin ve aynı zamanda Microsoft core fontlarını kuran bu runtime aşamasını kullanın:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` Debian ve Ubuntu paketindeki Microsoft core fontlarını indirir ve kurar; aynı EULA şartları uygulanır. `fc-cache` yazı tipi önbelleğini günceller.

Linux’ta Aspose.Slides.NET ile fontconfig kitaplığı eksik bir yazı tipinin yedeğini seçer ve `GetSubstitutions` bunu raporlamaz; bu yüzden *FontCheck* `No font substitutions.` mesajını verir. Hangi yazı tipinin bir ad için kullanıldığını görmek üzere konteyner içinde fontconfig’a sorun:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Microsoft core fontları yüklü olduğunda, Arial için Arial kullanılır:

```text
Arial.ttf: "Arial" "Regular"
```

Yoksa, `RUN` talimatı yalnızca `icu-libs libgdiplus font-dejavu` kurduğunda aynı komut şunu verir:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **SSS**

**Bir sunum sunucuda dönüştürüldüğünde neden farklı görünür?**

Sunucuda sunumun kullandığı yazı tipleri yoktur; bu yüzden Aspose.Slides metni, harf genişlikleri farklı olan bir yedek yazı tipiyle çizer. Hangi yazı tiplerinin yedeklendiğini görmek için *FontCheck*’i sunumun yazı tipi adlarıyla çalıştırın, ardından bu yazı tiplerini kurun veya uygulama klasöründen yükleyin.

**Derleme `ttf-mscorefonts-installer` paketini kurdu fakat Arial hâlâ yedekleniyor. Neden?**

Paket kurulmadan önce EULA kabul edilmemiştir; bu yüzden yükleyici fontları atlamıştır. `apt-get install` öncesinde `debconf-set-selections` komutunu ekleyin; bunu [Microsoft Core Fonts](#microsoft-core-fonts) bölümünde görebilirsiniz ve imajı yeniden oluşturun.

**PDF’yi açan bilgisayarın fontlara ihtiyacı var mı?**

Hayır. Bu örneklerde PDF, metni çizerken kullanılan fontları içerir; bu yüzden PDF herhangi bir bilgisayarda aynı görünür. Fontlar sadece Aspose.Slides’in sunumu render ettiği yerde gerekir.