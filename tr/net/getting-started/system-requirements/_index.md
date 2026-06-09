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

Aspose.Slides for .NET, Microsoft PowerPoint'in kurulu olmasını gerektirmez çünkü Aspose.Slides bağımsız bir Microsoft PowerPoint belge oluşturma, dönüştürme, sayfa düzeni ve işleme motorudur.

## **Desteklenen İşletim Sistemleri**

Aspose.Slides for .NET, .NET veya Mono çerçevesi yüklü olduğu herhangi bir 32‑bit veya 64‑bit işletim sistemini (sınırlı olmamak kaydıyla) destekler:

### **Windows**

- Microsoft Windows 2000 Server (x64, x86)
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine ve diğerleri)

### **Mac**

- Mac OS X

## **Desteklenen Çerçeveler**

Aspose.Slides for .NET .NET ve Mono çerçevelerini destekler:

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
- COM Interop desteği (COM, C++, VBScript)

### **Mono Çerçevesi**

- MONO Desteği MAC ve Linux platformlarında

## **Geliştirme Ortamları**

Aspose.Slides for .NET, .NET platformunu hedefleyen herhangi bir geliştirme ortamında uygulama geliştirmek için kullanılabilir, ancak aşağıdaki ortamlar açıkça desteklenir:

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

Şu anda, Aspose.Slides'in iki ana yapısı vardır — Aspose.Slides.NET ve Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Bu, ürünün ana sürümüdür. Standart .NET grafik motorunu kullanır.
- Windows dışı platformlarda, `libgdiplus` kütüphanesini ve bağımlılıklarını yüklemeniz gerekebilir.
- Aspose.Slides 25.3 sürümünden önce, Windows dışı platformlarda, Aspose.Slides ZIP paketinden .NET Standard 2.0 DLL'ini kullanmak gerekiyordu.
- Aspose.Slides 25.3 sürümünden itibaren, NuGet paketi Windows dışı sistemlerde de doğrudan kullanılabilir.
- Windows dışı sistemlerde çalışırken, uygulamanız başlangıçta aşağıdaki satırı içermelidir:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **25.3 sürümünden itibaren, bu paketi .NET'i destekleyen platformlarda, örneğin Linux aarch64 (ARM64) üzerinde kullanabilirsiniz.**

#### **Linux Alpine için Ek Paketler**

Alpine Linux konteynerinde Aspose.Slides for .NET çalıştırırken, yalnızca `libgdiplus` kurmak yeterli olmayabilir. Alpine konteynerleri genellikle varsayılan olarak yazı tipleri içermez. Yazı tipi bulunmazsa, render veya dönüştürme işlemleri aşağıdaki gibi bir hata ile başarısız olabilir:
```text
System.ArgumentException: Font '?' cannot be found
```
Alpine’da Aspose.Slides kullanmak için `libgdiplus` ile en az bir yazı tipi paketini birlikte kurun.

**Seçenek 1: DejaVu Yazı Tipleri**

Önerilen seçenek ttf-dejavu paketini kurmaktır:
```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```
`ttf-dejavu` paketi, `fontconfig`, `encodings`, `mkfontscale` ve `mkfontdir` gibi gerekli yazı tipi bağımlılıklarını otomatik olarak kurar. Çoğu kullanım senaryosu için ek yazı tipi paketine gerek yoktur.

**Seçenek 2: Microsoft Core Yazı Tipleri**

Eğer sunumlarınız Arial, Times New Roman, Courier New veya Verdana gibi Microsoft'a özgü yazı tiplerini kullanıyorsa, bunun yerine Microsoft Core Fonts paketini kurun:
```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```
Bu seçeneği yalnızca işlenen sunumların Microsoft yazı tiplerine ihtiyaç duyduğu durumlarda kullanın. Çoğu senaryoda `ttf-dejavu` kurulumu daha basit ve güvenilirdir.

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Bu, Aspose.Slides ekibi tarafından geliştirilen özel bir çapraz platform grafik motoru kullanan Aspose.Slides sürümüdür.  
Windows dışı platformlarda, `fontconfig` kütüphanesi gerekebilir.

**Desteklenen Platformlar**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)  
- *macOS*: x86_64, ARM64 (aarch64)

**Desteklenmeyen Platformlar**
- *Windows 11 ARM* (ARM64) — *Şu anda değerlendirme altında değil*

{{%  alert  title="Notes"  color="primary"  %}}  
Linux x64 için GLIBC 2.23+; Linux ARM64 için GLIBC 2.39+ gereklidir. CentOS 7 (GLIBC 2.14) gibi sistemler desteklenmez. Aspose.Slides’i CentOS 7 veya diğer uyumsuz sistemlerde (ör. Alpine) çalıştırmanız gerekiyorsa, lütfen standart paketi kullanın: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **SSS**

**Dönüştürme ve render için Microsoft PowerPoint'in kurulu olması gerekiyor mu?**

Hayır, PowerPoint gerekli değildir; Aspose.Slides, sunumları [oluşturmak](/slides/tr/net/create-presentation/), değiştirmek, [dönüştürmek](/slides/tr/net/convert-presentation/) ve [renderlamak](/slides/tr/net/convert-powerpoint-to-png/) için bağımsız bir motorudur.

**Doğru render için hangi yazı tipleri gerekir?**

Sunumda kullanılan yazı tipleri veya uygun yerine geçebilecekleri işletim sisteminde mevcut olmalıdır. Linux ve macOS'ta tutarlı render için yaygın yazı tipi paketlerini kurun.

Alpine Linux konteynerleri için `libgdiplus` dışında en az bir yazı tipi paketi kurun. Önerilen minimal yapı `libgdiplus` ile `ttf-dejavu` paketidir. Arial, Times New Roman, Courier New veya Verdana gibi Microsoft yazı tipleri gerekiyorsa, `fontconfig` ile birlikte `msttcorefonts-installer` kullanın.

**Linux'ta özel bir yazı tipi neden yedek veya eksik metin olarak render ediyor?**

Eğer yazı tipi dosyasının ad tablosu girdileri tutarsız veya bozuksa, Linux yazı tipi eşleme yığını (FreeType/fontconfig) geçersiz bir kaydı seçebilir ve bu da yazı tipinin çözülememesine neden olur. Düzeltülmüş ad tablosu kayıtlarına sahip bir sürüm kullanmak veya tutarlı bir yedek kurmak sorunu çözer.