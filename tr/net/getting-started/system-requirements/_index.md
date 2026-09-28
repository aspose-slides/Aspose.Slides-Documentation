---
title: Sistem Gereksinimleri
type: docs
weight: 60
url: /tr/net/system-requirements/
keywords:
- sistem gereksinimleri
- desteklenen platformlar
- hedef çerçeveler
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in kurulum öncesinde neye ihtiyaç duyduğunu kontrol edin: her NuGet paketinin hedeflediği çerçeveler, desteklenen işletim sistemleri ve işlemciler, ve Linux'un gerektirdiği kitaplıklar ve fontlar."
---
## **Giriş**

Aspose.Slides for .NET bağımsız bir kütüphanedir: Microsoft PowerPoint veya Microsoft Office’e ihtiyaç duymaz. İki NuGet paketi olarak yayınlanmıştır, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) ve [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Her ikisi de aynı Aspose.Slides ad alanlarını ve sınıflarını sağlar; hedefledikleri çerçeveler ve slaytları nasıl çizdikleri bakımından farklıdır; bu da nerede çalışacaklarını ve neye ihtiyaç duyacaklarını belirler.

Bu makale, her paketin desteklediği .NET sürümlerini ve platformları, Linux’un ihtiyaç duyduğu sistem kitaplıklarını ve fontları listeler ve kurulumunuzu kontrol eden kısa bir programla sona erer. Bir paketi bir projeye eklemek için [Kurulum](/slides/tr/net/installation/) bölümüne bakın.

## **Desteklenen .NET Sürümleri**

Her paket, hedef çerçeve başına bir Aspose.Slides derlemesi içerir ve NuGet, projenizin hedef çerçevesiyle eşleşen derlemeyi seçer.

| Paket | Paketteki hedef çerçeveler | Projenizin hedefleyebileceği çerçeveler |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 veya daha yeni; .NET 6 veya daha yeni, .NET 8, .NET 9 ve .NET 10 dahil |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 veya daha yeni, .NET 8, .NET 9 ve .NET 10 dahil |

`netstandard2.0` derlemesi, bir .NET Standard 2.0 sınıf kitaplığının Aspose.Slides.NET’e referans vermesini sağlar. Böyle bir kitaplık kullanan bir uygulama, uygulamanın kendi hedef çerçevesine uyan derlemeyi çalıştırır: örneğin bir .NET 8 uygulaması `net6.0` derlemesini çalıştırır.

## **Desteklenen İşletim Sistemleri ve İşlemciler**

**Aspose.Slides.NET** yalnızca işlemci bağımsız (AnyCPU) yönetilen kod içerir; bu nedenle onu yükleyen .NET çalışma zamanının işlemci mimarisi üzerinde çalışır. Slaytları, Microsoft’un System.Drawing.Common kitaplığı aracılığıyla çizer; bu kitaplık Microsoft tarafından sadece Windows üzerinde desteklenir. Linux’da Aspose.Slides.NET bu nedenle `libgdiplus` kitaplığına ve bir başlangıç anahtarına ihtiyaç duyar; ayrıntılar [Linux](#linux) bölümünde açıklanmıştır. Debian, Ubuntu ve Alpine Linux gibi `libgdiplus` sağlayan Linux dağıtımlarında çalışır.

**Aspose.Slides.NET6.CrossPlatform** slaytları kendi grafik motoru ile çizer. Motor, paket içinde platform başına bir derleme içeren yerel bir kitaplıktır; bu nedenle paket yalnızca şu platformlarda çalışır:

| İşletim sistemi | İşlemciler | Notlar |
|---|---|---|
| Windows | x86, x64 | ARM64 üzerindeki Windows desteklenmez. |
| Linux | x64, ARM64 | x64 için glibc 2.23 veya daha yeni, ARM64 için glibc 2.39 veya daha yeni gerekir. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform, musl tabanlı Alpine Linux gibi glibc yerine musl kullanan dağıtımlarda ya da CentOS 7 gibi eski glibc sürümlerine sahip dağıtımlarda çalışmaz. Bu sistemlerde Aspose.Slides.NET kullanın.

Windows’da Aspose.Slides.NET6.CrossPlatform’un yerel kitaplığı Microsoft Visual C++ çalışma zamanı (*MSVCP140.dll* ve *VCRUNTIME140.dll*, x64 için ayrıca *VCRUNTIME140_1.dll*) kullanır. Bu dosyalar hedef makinede eksikse, [Microsoft Visual C++ Yeniden Dağıtılabilir Paketi](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170) yükleyin.

## **Linux**

Her iki paket de Linux’da ek sistem kitaplıklarına ihtiyaç duyar. Bunlar olmadan, [Sunum Oluşturma](/slides/tr/net/create-presentation/) bölümündeki ilk örnek, dosyayı kaydetmek yerine bir istisna atar. Aşağıdaki komutlar Debian ve Ubuntu içindir; bu dağıtımlarda her kitaplık aynı zamanda DejaVu fontlarını (`fonts-dejavu-core`) da getirir, böylece ek font paketlerine gerek kalmadan metin doğru görüntülenir.

### **Aspose.Slides.NET6.CrossPlatform**

Paketin Linux kitaplığı `fontconfig` kitaplığına ihtiyaç duyar:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Olmadan, bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturulması `TypeInitializationException` hatası verir; içindeki `DllNotFoundException` `libfontconfig.so.1` dosyasının açılamadığını bildirir.

Minimal temel görüntüler `fontconfig` içermeyebilir. Örneğin .NET 8 için AWS Lambda temel görüntüsü ne `fontconfig` ne de herhangi bir font içerir. Üzerinde oluşturulan bir konteyner görüntüsünde `dnf install -y fontconfig` komutunu çalıştırın; bu aynı zamanda Noto Sans fontlarını da kurar.

### **Aspose.Slides.NET**

Paketin Linux’da iki şeye ihtiyacı vardır:

1. `libgdiplus` kitaplığı:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. `System.Drawing.EnableUnixSupport` anahtarı, Aspose.Slides çağrısı yapılmadan önce, uygulamanızın başlangıcında etkinleştirilmelidir. Üst‑seviye ifadeler kullanan bir *Program.cs* dosyasında, `using` yönergelerinden sonra ekleyin:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

`libgdiplus` olmadan bir sunum kaydedilmeye çalışıldığında `TypeInitializationException` ve içindeki `DllNotFoundException` `libgdiplus`’un yüklenemediğini bildirir. Anahtar eklenmezse, iç istisna `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms` olur.

{{% alert color="warning" title="Warning" %}}
Anahtar yalnızca Aspose.Slides.NET’in bağımlı olduğu System.Drawing.Common 6 ile çalışır. Microsoft, System.Drawing.Common 7’de bu özelliği kaldırdı. Projeniz doğrudan ya da başka bir paket aracılığıyla System.Drawing.Common 7 veya daha yenisine başvuruyorsa, Aspose.Slides.NET Linux’da `libgdiplus` yüklü ve anahtar etkin olsa bile `PlatformNotSupportedException` hatası verir. Bu durumda Aspose.Slides.NET6.CrossPlatform kullanın.
{{% /alert %}}

### **Alpine Linux**

Alpine Linux’ta yukarıda açıklanan anahtar ile Aspose.Slides.NET kullanın. Alpine görüntüleri genellikle font içermez ve yalnızca `libgdiplus` kurulduğunda da font kurulmaz; bu yüzden en az bir font paketiyle birlikte `libgdiplus` kurun. Font olmadan bir sunum kaydedilmeye çalışıldığında şu hata alınır:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Seçenek 1: DejaVu fontları**

Önerilen seçenek `ttf-dejavu` paketidir:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Güncel Alpine sürümlerinde `ttf-dejavu`, `font-dejavu` paketini kurar; bu paket de `fontconfig` ve bağımlı olduğu font araçlarını getirir.

**Seçenek 2: Microsoft temel fontları**

Sunumlarınız Arial, Times New Roman, Courier New veya Verdana gibi Microsoft fontlarını kullanıyorsa, bunun yerine Microsoft temel fontlarını kurun. `update-ms-fonts` adımı, görüntü oluşturulurken internet erişimi gerektiren fontları indirir:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Küreselleştirme Desteği**

Her iki paket de .NET küreselleştirme desteğine ihtiyaç duyar; Linux üzerindeki .NET bu desteği ICU kitaplıkları aracılığıyla sağlar. [globalization-invariant modu](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization) etkinken bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturmak `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode` hatası verir.

Bazı konteyner görüntüleri bu modu açar. Örneğin Alpine Linux için .NET çalışma zamanı görüntüleri (`runtime-deps`, `runtime` ve `aspnet`) `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` ayarlar ve ICU içermez. Bu görüntüler üzerine oluşturulan bir imajda ICU kurun ve modu kapatın:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Ayrıca proje dosyanızın `InvariantGlobalization` özelliğini `true` olarak ayarlamadığından emin olun.

## **Kurulumunuzu Kontrol Edin**

Bir paketin ve gereksinimlerinin yerinde olduğunu kontrol etmek için bir sunumu kaydeden ve bir slaytı görüntüye dönüştüren bir program çalıştırın. Kaydetme ve görüntüleme, grafik kitaplığı ve fontları kullanır; bunlar yukarıdaki Linux gereksinimlerinin sağladığı şeylerdir.

Bir konsol uygulaması oluşturun, paketi [Kurulum](/slides/tr/net/installation/) bölümünde açıklandığı gibi ekleyin, *Program.cs* içeriğini aşağıdaki kodla değiştirin ve `dotnet run` komutunu çalıştırın. Linux’da Aspose.Slides.NET kullanıyorsanız, `using` yönergelerinden sonra [Linux](#linux) bölümünde gösterildiği gibi `System.Drawing.EnableUnixSupport` anahtar ifadesini ekleyin. Program, üst‑seviye ifadeler ve `using` bildirileri kullanır; bunlar C# 9 veya daha yenisini gerektirir. .NET 6 veya daha yeni hedefleyen projeler varsayılan olarak yeni bir C# sürümü alır; .NET Framework hedefliyorsanız proje dosyasına bir `PropertyGroup` içinde `<LangVersion>latest</LangVersion>` ekleyin.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

Program, ilk slayta bir dikdörtgen ve metin ekler, sunumu *hello.pptx* olarak [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) yöntemiyle kaydeder. Ardından slaytı [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) ile görüntüye dönüştürür ve sonucu *hello.png* olarak [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) ve [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) formatıyla kaydeder. 1 ölçek faktörü, bir nokta başına bir piksel oluşturur; böylece varsayılan 720 × 540 nokta slayt 720 × 540 piksel görüntüye dönüşür ve metin dikdörtgen içinde görünür. Lisans olmadan her iki dosya da değerlendirme filigranı taşır; bkz. [Lisanslama](/slides/tr/net/licensing/). Bir gereksinim eksikse, program [Linux](#linux) bölümünde açıklanan istisnalardan biriyle durur.

## **Geliştirme Araçları**

Aspose.Slides kullanan uygulamaları, hedef çerçevenizi destekleyen herhangi bir araçla derleyebilirsiniz: Windows, Linux ve macOS üzerinde .NET SDK ve `dotnet` komut satırı arabirimi, ya da Windows üzerindeki Visual Studio. [Kurulum](/slides/tr/net/installation/) her iki yöntemi de açıklar.

## **SSS**

**Dönüştürme ve görüntüleme için Microsoft PowerPoint yüklü olması gerekiyor mu?**

Hayır, PowerPoint gerekli değildir. Aspose.Slides, sunumları [oluşturmak](/slides/tr/net/create-presentation/), değiştirmek, [dönüştürmek](/slides/tr/net/convert-presentation/) ve [görselleştirmek](/slides/tr/net/convert-powerpoint-to-png/) için bağımsız bir motor sağlar.

**Hangi paketi kullanmalıyım?**

Windows’da Aspose.Slides.NET, Linux ve macOS’da Aspose.Slides.NET6.CrossPlatform kullanın. Alpine Linux’da, glibc’si yukarıda listelenen sürümlerin altında olan Linux sistemlerinde ve .NET Framework hedefleyen projelerde Aspose.Slides.NET tercih edin. Projeye yalnızca bu iki paketten birini ekleyin.

**Doğru görüntüleme için hangi fontlar gerekir?**

Sunumda kullanılan fontlar ya da uygun ikameler işletim sistemi içinde bulunmalıdır. Linux ve macOS’da tutarlı görüntüleme için sunumunuzun ihtiyaç duyduğu font paketlerini kurun. Alpine Linux’da, `libgdiplus` ile birlikte en az bir font paketi kurun; ayrıntılar [Alpine Linux](#alpine-linux) bölümündedir.

**Özel bir font Linux’ta yedek font ya da eksik metin olarak neden görüntüleniyor?**

Font dosyasının ad‑tablosu girdileri tutarsız ya da bozuksa, Linux font eşleştirme yığını (FreeType/fontconfig) geçersiz bir kaydı seçebilir ve font çözülemez. Düzeltildiği teyit edilen bir font sürümü kullanmak ya da tutarlı bir yedek font kurmak sorunu çözer.