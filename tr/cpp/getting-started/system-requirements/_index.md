---
title: Sistem Gereksinimleri
type: docs
weight: 80
url: /tr/cpp/system-requirements/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ sistem gereksinimlerini keşfedin. Windows, Linux ve macOS'ta sorunsuz PowerPoint ve OpenDocument desteği sağlayın."
---
## **Giriş**

Aspose.Slides, Microsoft PowerPoint'in yüklü olmasını gerektirmez çünkü Aspose.Slides bağımsız bir Microsoft PowerPoint belge oluşturma, dönüştürme, sayfa düzeni ve render motorudur.

## **Desteklenen İşletim Sistemleri**
Aspose.Slides for C++, yerel bir C++ kitaplığıdır. Aspose.Slides for C++ aşağıdaki 64-bit ve 32-bit işletim sistemlerini ve platformları destekler:

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- Ubuntu 16.04 veya daha yenisi.
- CentOS 8 veya daha yenisi.
- Fedora 24 veya daha yenisi.
- Ve glibc 2.23 veya daha yenisiyle diğer Linux x86_64 sürümleri.

### **macOS**
- macOS Monterey 12.1 veya daha yenisi.

## **Geliştirme Ortamları**
Windows, Linux veya macOS için uygulama geliştirirken Aspose.Slides for C++'ı kullanabilirsiniz.

### **Windows**
- Microsoft Visual Studio 2017 veya daha yenisi.
- CMake 3.18 veya daha yenisi.

### **Linux**
- Clang 3.9 veya daha yenisi.
- GCC 6.1 veya daha yenisi.
- CMake 3.18 veya daha yenisi.

### **macOS**
- Xcode 13.4 veya daha yenisi.

## **SSS**

**Dönüştürme ve renderleme için Microsoft PowerPoint yüklü olması gerekiyor mu?**

Hayır, PowerPoint gerekmez; Aspose.Slides, sunumları [oluşturma](/slides/tr/cpp/create-presentation/), değiştirme, [dönüştürme](/slides/tr/cpp/convert-presentation/), ve [renderleme](/slides/tr/cpp/convert-powerpoint-to-png/) için bağımsız bir motorudur.

**Doğru renderleme için hangi yazı tiplerine ihtiyaç var?**

Uygulamada, sunumda kullanılan yazı tipleri veya uygun [alternatifler](/slides/tr/cpp/font-substitution/) mevcut olmalıdır. Linux/macOS'ta tutarlı renderleme sağlamak için yaygın yazı tipi paketlerini yüklemeniz tavsiye edilir.

**Özel bir yazı tipi Linux'ta yedek veya eksik metin olarak neden renderlanıyor?**

Yazı tipi dosyasında tutarsız veya bozuk name-table girdileri varsa, Linux yazı tipi eşleştirme yığını (FreeType/fontconfig) geçersiz bir kayıt seçebilir ve bu da yazı tipinin çözülememesine yol açar. Düzeltildiği name-table kayıtları içeren bir yazı tipi sürümü kullanmak veya tutarlı bir yedek kurmak sorunu çözer.