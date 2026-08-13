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
description: "Aspose.Slides for .NET sistem gereksinimlerini keşfedin. Windows, Linux ve macOS'ta sorunsuz PowerPoint ve OpenDocument desteğini sağlayın."
---
## **Giriş**

Aspose.Slides for .NET, Microsoft PowerPoint'in kurulu olmasını gerektirmez çünkü Aspose.Slides bağımsız bir Microsoft PowerPoint belge oluşturma, dönüştürme, sayfa düzeni ve işleme motorudur.

## **Desteklenen İşletim Sistemleri**

Aspose.Slides for .NET, .NET veya Mono çerçevesi yüklü olan herhangi bir 32‑bit veya 64‑bit işletim sistemini (ancak bunlarla sınırlı değildir) destekler:

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

## **Desteklenen Çerçeveler**

Aspose.Slides for .NET, .NET ve Mono çerçevelerini destekler:

### **.NET Framework'leri**

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
- COM Interop support (COM, C++, VBScript)

### **Mono Çerçevesi**

- MAC ve Linux platformlarında MONO Desteği

## **Geliştirme Ortamları**

Aspose.Slides for .NET, .NET platformunu hedefleyen herhangi bir geliştirme ortamında kullanılabilir, ancak aşağıdaki ortamlar açıkça desteklenmektedir:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides Ana Derlemeleri**

Şu anda iki ana derleme vardır — Aspose.Slides.NET ve Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Bu, ürünün ana sürümüdür. Standart .NET grafik motorunu kullanır.
- Windows dışı platformlarda `libgdiplus` kütüphanesini ve bağımlılıklarını kurmanız gerekebilir.
- Aspose.Slides 25.3 sürümünden önce, Windows dışı platformlarda Aspose.Slides ZIP paketindeki .NET Standard 2.0 DLL'i kullanmak zorundaydınız.
- Aspose.Slides 25.3 sürümünden itibaren NuGet paketi, Windows dışı sistemlerde doğrudan kullanılabilir.
- Windows dışı sistemlerde çalıştırıldığında, uygulamanız başlangıçta aşağıdaki satırı içermelidir:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **25.3 sürümünden itibaren, Linux aarch64 (ARM64) gibi .NET destekleyen platformlarda bu paketi kullanabilirsiniz.**

#### **Linux Alpine için Ek Paketler**

Aspose.Slides for .NET bir Alpine Linux konteynerinde çalıştırıldığında yalnızca `libgdiplus` kurmak yeterli olmayabilir. Alpine konteynerleri varsayılan olarak yazı tipleri içermez. Yazı tipi bulunmadığında, render veya dönüştürme işlemleri aşağıdaki gibi bir hata ile başarısız olabilir:

```text
System.ArgumentException: Font '?' cannot be found
```

Alpine'de Aspose.Slides kullanmak için `libgdiplus` ile birlikte en az bir yazı tipi paketi kurun.

**Seçenek 1: DejaVu Yazı Tipleri**

Önerilen seçenek, `ttf-dejavu` paketini kurmaktır:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

`ttf-dejavu` paketi, `fontconfig`, `encodings`, `mkfontscale` ve `mkfontdir` gibi gerekli yazı tipi bağımlılıklarını otomatik olarak kurar. Çoğu kullanım senaryosu için ekstra bir yazı tipi paketi gerekmez.

**Seçenek 2: Microsoft Core Yazı Tipleri**

Sunumlarınız Arial, Times New Roman, Courier New veya Verdana gibi Microsoft’a özgü yazı tipleri kullanıyorsa, bunun yerine Microsoft Core Fonts paketini kurun:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Bu seçeneği yalnızca işlenen sunumların Microsoft yazı tiplerine ihtiyaç duyduğu durumlarda kullanın. Çoğu senaryo için `ttf-dejavu` kurmak daha basit ve güvenilirdir.

**Küreselleştirme için ek gereksinimler**

Alpine'de doğru küreselleştirme desteği sağlamak için `icu-libs` paketini kurun ve invariant modunu devre dışı bırakın:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Bu, Aspose.Slides ekibi tarafından geliştirilen özel bir çapraz platform grafik motoru kullanan sürümdür.  
Windows dışı platformlarda `fontconfig` kütüphanesi gerekebilir.

**Desteklenen Platformlar**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Desteklenmeyen Platformlar**
- *Windows 11 ARM* (ARM64) — *Şu anda değerlendirme altında değildir*

{{%  alert  title="Notes"  color="info"  %}}  
Linux x64 için GLIBC 2.23+ gerekir; Linux ARM64 için GLIBC 2.39+ gerekir. CentOS 7 (GLIBC 2.14) gibi sistemler desteklenmez. Aspose.Slides'ı CentOS 7 veya diğer uyumsuz sistemlerde (ör. Alpine) çalıştırmanız gerekiyorsa, lütfen standart paketi kullanın: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}}

## **SSS**

### Dönüştürmeler ve render işlemleri için Microsoft PowerPoint yüklü olması gerekiyor mu?

Hayır, PowerPoint gerekli değildir; Aspose.Slides, sunumları [oluşturmak](/slides/tr/net/create-presentation/), değiştirmek, [dönüştürmek](/slides/tr/net/convert-presentation/) ve [renderlamak](/slides/tr/net/convert-powerpoint-to-png/) için bağımsız bir motor sağlar.

### Doğru render için hangi yazı tipleri gereklidir?

Sunumda kullanılan yazı tipleri veya uygun ikameleri işletim sisteminde bulunmalıdır. Linux ve macOS'ta tutarlı render sağlamak için ortak yazı tipi paketlerini kurun.

Alpine Linux konteynerlerinde `libgdiplus` dışına en az bir yazı tipi paketi kurun. Önerilen minimum yapılandırma `libgdiplus` ile birlikte `ttf-dejavu` paketidir. Arial, Times New Roman, Courier New veya Verdana gibi Microsoft yazı tiplerine ihtiyaç varsa, `msttcorefonts-installer` paketini `fontconfig` ile birlikte kullanın.

### Neden özel bir yazı tipi Linux'ta yedek veya eksik metin olarak render oluyor?

Yazı tipi dosyasının ad‑tablosu girdileri tutarsız veya bozuksa, Linux yazı tipi eşleştirme yığını (FreeType/fontconfig) geçersiz bir kaydı seçebilir ve yazı tipi çözülemez. Düzeltilmiş ad‑tablosu kayıtlarına sahip bir sürüm kullanmak veya tutarlı bir ikame kurmak sorunu çözer.