---
title: Sistem Gereksinimleri
type: docs
weight: 60
url: /tr/net/system-requirements/
keywords:
- sistem gereksinimleri
- işletim sistemi
- kurulum
- bağımlılıklar
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET sistem gereksinimlerini keşfedin. Windows, Linux ve macOS üzerinde sorunsuz PowerPoint ve OpenDocument desteği sağlayın."
---
## **Giriş**

Aspose.Slides for .NET, Aspose.Slides bağımsız bir Microsoft PowerPoint belge oluşturma, dönüştürme, sayfa düzeni ve render motoru olduğundan Microsoft PowerPoint'in yüklü olmasını gerektirmez.

## **Desteklenen İşletim Sistemleri**

Aspose.Slides for .NET, .NET veya Mono framework’ünün kurulu olduğu herhangi bir 32‑bit veya 64‑bit işletim sistemini (sınırlı olmamak kaydıyla) destekler:

### **Windows**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine ve diğerleri)

### **Mac**

- Mac OS X

## **Desteklenen Çatılar**

Aspose.Slides for .NET, .NET ve Mono çatılarının her ikisini de destekler:

### **.NET Çatılar**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop desteği (COM, C++, VBScript)

### **Mono Çatısı**

- MAC ve Linux platformlarında MONO Desteği

## **Geliştirme Ortamları**

Aspose.Slides for .NET, .NET platformunu hedefleyen herhangi bir geliştirme ortamında kullanılabilir; ancak aşağıdaki ortamlar özellikle desteklenir:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides Ana Yapıları**

Şu anda Aspose.Slides’in iki ana yapısı vardır — Aspose.Slides.NET ve Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Bu, ürünün ana sürümüdür. Standart .NET grafik motorunu kullanır.
- Windows dışı platformlarda `libgdiplus` kütüphanesini ve bağımlılıklarını kurmanız gerekebilir.
- Aspose.Slides 25.3 sürümünden önce, Windows dışı platformlarda Aspose.Slides ZIP paketindeki .NET Standard 2.0 DLL’i kullanılmalıydı.
- Aspose.Slides 25.3 sürümünden itibaren NuGet paketi, Windows dışı sistemlerde doğrudan kullanılabilir.
- Windows dışı sistemlerde çalıştırıldığında uygulamanız başlangıçta aşağıdaki satırı içermelidir:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **25.3 sürümünden itibaren bu paketi Linux aarch64 (ARM64) gibi .NET’i destekleyen platformlarda kullanabilirsiniz.**

#### **Linux Alpine için Ek Paketler**

Aspose.Slides for .NET bir Alpine Linux konteynerinde çalıştırılırken yalnızca `libgdiplus` kurulması yeterli olmayabilir. Alpine konteynerleri genellikle varsayılan olarak font içermez. Font bulunmadığında render veya dönüşüm işlemleri aşağıdaki gibi bir hata ile başarısız olabilir:

```text
System.ArgumentException: Font '?' cannot be found
```
Alpine’da Aspose.Slides kullanmak için `libgdiplus` ile birlikte en az bir font paketi kurmalısınız.

**Seçenek 1: DejaVu Fontları**

Önerilen seçenek `ttf-dejavu` paketini kurmaktır:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

`ttf-dejavu` paketi, `fontconfig`, `encodings`, `mkfontscale` ve `mkfontdir` gibi gerekli font bağımlılıklarını otomatik olarak kurar. Çoğu kullanım senaryosu için ek font paketi gerekmez.

**Seçenek 2: Microsoft Core Fontları**

Sunumlarınız Arial, Times New Roman, Courier New veya Verdana gibi Microsoft‑özel fontlar kullanıyorsa bunun yerine Microsoft Core Fontları kurun:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Bu seçeneği yalnızca işlenen sunumların Microsoft fontları gerektirdiği durumlarda kullanın. Çoğu senaryoda `ttf-dejavu` kurulumu daha basit ve daha güvenilirdir.

**Küreselleştirme için ek gereksinimler**

Alpine’da doğru küreselleştirme desteğini etkinleştirmek için `icu-libs` paketini kurun ve invariant modu devre dışı bırakın:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Bu, Aspose.Slides ekibi tarafından geliştirilen özel bir çapraz‑platform grafik motoru kullanan sürümdür.  
Windows dışı platformlarda `fontconfig` kütüphanesi gerekebilir.

**Desteklenen Platformlar**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Desteklenmeyen Platformlar**
- *Windows 11 ARM* (ARM64) — *Şu anda değerlendirilmiyor*

{{%  alert  title="Notes"  color="primary"  %}}  
Linux x64 için GLIBC 2.23+, Linux ARM64 için GLIBC 2.39+ gerekir; CentOS 7 (GLIBC 2.14) gibi sistemler desteklenmez. Aspose.Slides’i CentOS 7 veya başka uyumsuz sistemlerde (ör. Alpine) çalıştırmanız gerekiyorsa standart paketi kullanın: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **SSS**

**Dönüşüm ve render için Microsoft PowerPoint yüklü olmak zorunda mı?**

Hayır, PowerPoint gerekli değildir; Aspose.Slides, sunumları [oluşturmak](/slides/tr/net/create-presentation/), değiştirmek, [dönüştürmek](/slides/tr/net/convert-presentation/) ve [renderlamak](/slides/tr/net/convert-powerpoint-to-png/) için bağımsız bir motor sağlar.

**Doğru render için hangi fontlar gerekir?**

Sunumda kullanılan fontlar ya da uygun ikameler işletim sisteminde bulunmalıdır. Linux ve macOS’da tutarlı render sağlamak için yaygın font paketleri kurun.

Alpine Linux konteynerlerinde `libgdiplus` dışında en az bir font paketi kurmalısınız. Önerilen minimal kurulum `libgdiplus` ile `ttf-dejavu` paketidir. Arial, Times New Roman, Courier New veya Verdana gibi Microsoft fontları gerekiyorsa `msttcorefonts-installer` paketini `fontconfig` ile birlikte kullanın.

**Özel bir font Linux’da yedek font ya da eksik metin olarak neden gösterilir?**

Font dosyasının ad‑tablosu kayıtları tutarsız ya da bozuksa, Linux font eşleme yığını (FreeType/fontconfig) geçersiz bir kaydı seçebilir ve font çözülemez. Düzeltilmiş ad‑tablosu kayıtlarına sahip bir font sürümü kullanmak ya da tutarlı bir ikame kurmak sorunu çözer.