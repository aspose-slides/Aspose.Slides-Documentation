---
title: Kurulum
type: docs
weight: 70
url: /tr/net/installation/
keywords:
- Aspose.Slides yükleme
- Aspose.Slides indirme
- Aspose.Slides kullanımı
- Aspose.Slides kurulumu
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'i hızlı bir şekilde nasıl kuracağınızı öğrenin. Adım adım kılavuz, sistem gereksinimleri ve kod örnekleri — bugün PowerPoint sunumlarıyla çalışmaya başlayın!"
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET'in Windows, Linux ve macOS üzerinde nasıl kurulacağını açıklar. NuGet tabanlı kuruluma odaklanır ve Windows'ta NuGet Paket Yöneticisi veya Paket Yöneticisi Konsolu aracılığıyla, Linux'ta bir .NET projesine ve macOS'ta bir Visual Studio projesine kütüphanenin nasıl ekleneceğini gösterir. Ayrıca paketin nasıl güncelleneceğini ve gerektiğinde ön sürüm (prerelease) derlemelerinin nasıl yükleneceğini açıklar.

Kurulumdan önce, desteklenen işletim sistemlerini, .NET uygulamalarını ve ek bağımlılıkları [Sistem Gereksinimleri](/slides/tr/net/system-requirements/) bölümünde inceleyin.

## **Windows**
NuGet, PC'lerde Aspose API'lerini .NET için indirme ve kurmanın en kolay yolunu sağlar. 

### **Yöntem 1: NuGet Paket Yöneticisi'nden Aspose.Slides'ı Yükleme veya Güncelleme**

1. Microsoft Visual Studio'yu açın. 
2. Basit bir konsol uygulaması oluşturun veya mevcut bir projeyi açın. 
3. **Tools** > **NuGet package manager** yolunu izleyin. 
4. **Browse** altında, metin alanına *Aspose Slides* yazın ve arama yapın. 
{{% image img="installation_1.png" alt="NuGet Paket Yöneticisinden Aspose.Slides Kurulumu - 1" %}}
5. **Aspose.Slides.NET** üzerine tıklayın ve ardından **Install**'a tıklayın. 
   * Aspose.Slides'ı zaten yüklediyseniz ve güncellemek istiyorsanız **Update**'a tıklayın. 

Seçilen API projenize indirilir ve referans olarak eklenir.

### **Yöntem 2: Paket Yöneticisi Konsolu Üzerinden Aspose.Slides'ı Yükleme veya Güncelleme**

Bu, paket yöneticisi konsolu üzerinden [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) referansını eklemenin yoludur:

1. Microsoft Visual Studio'yu açın. 
2. Basit bir konsol uygulaması oluşturun veya mevcut bir projeyi açın. 
3. **Tools** > **Library Package Manager** > **Package Manager Console** yolunu izleyin. 
![todo:image_alt_text](installation_2.png)
4. Bu komutu çalıştırın: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
En son tam sürüm uygulamanıza kurulur. 

* Alternatif olarak, `-prerelease` son ekini ekleyerek en son sürümün (sıcak düzeltmeler dahil) kurulmasını sağlayabilirsiniz.

 **Installing Aspose.Slides.NET** ipucu, pencerenin alt kısmında görünür. 
![todo:image_alt_text](installation_4.png)

İndirme tamamlandığında bazı onay mesajları görmelisiniz. 

[Aspose EULA](https://about.aspose.com/legal/eula) ile aşina değilseniz, URL'de referans verilen lisansı okumanız önerilir. 
![todo:image_alt_text](installation_5.png)

Uygulamanızda Aspose.Slides'ın başarıyla eklendiğini ve referans alındığını görmelisiniz. 
![todo:image_alt_text](installation_6.png)

Paket Yöneticisi Konsolu'nda `Update-Package Aspose.Slides.NET` komutunu çalıştırarak Aspose.Slides paketindeki güncellemeleri kontrol edebilirsiniz. Bulunan güncellemeler otomatik olarak kurulur. `-prerelease` son ekini ekleyerek en son sürümü de güncelleyebilirsiniz.
#### **Paylaşılan Sunucu Ortamında Çalıştırırken Dikkat Edilmesi Gerekenler**
Aspose .NET bileşenlerini **Full Trust** izin setiyle çalıştırmanızı şiddetle tavsiye ederiz; çünkü Aspose bileşenleri bazen sanal dizinin dışında bulunan kayıt defteri ayarları ve dosyalara erişim gerektirebilir—örneğin, font dosyalarını okurken.

Ayrıca Aspose.NET bileşenleri temel .NET sistem sınıflarına dayanır ve bu sınıfların bazıları belirli durumlarda Full Trust izni gerektirir.

Farklı şirketlerin uygulamalarını barındıran Internet Service Provider'lar genellikle **Medium Trust** güvenlik seviyesini uygular. .NET 2.0 ortamında bu güvenlik seviyesi, Aspose.Slides işlemlerini etkileyebilecek kısıtlamalara yol açabilir:

- **RegistryPermission** mevcut değildir. Bu, belgeleri işlerken yüklü fontları listelemek için kayıt defterine erişilemeyeceği anlamına gelir. 
- **FileIOPermission** kısıtlanmıştır. Bu, yalnızca uygulamanızın sanal dizin hiyerarşisindeki dosyalara erişebileceğiniz anlamına gelir. Bu durum, dışa aktarma sırasında fontların okunamamasına da yol açabilir. 

Yukarıdaki nedenlerden dolayı Aspose.Slides'ı **Full Trust** izinleriyle çalıştırmanızı şiddetle öneriyoruz. **Medium trust** kullanırsanız, bazı kütüphane özellikleri (örneğin render işlemleri) belirli görevlerde çalışmayabilir. 

## **Linux**

NuGet, Linux'ta Aspose.Slides for .NET'i indirme ve kurmanın en kolay yolunu sağlar. .NET projenize [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) paketini ekleyin.

## **macOS**

NuGet, Mac'lerde Aspose.Slides for .NET'i indirme ve kurmanın en kolay yolunu sağlar.

### **Aspose.Slides'ı Kurun**

1. Visual Studio'yu açın. 
2. Basit bir konsol uygulaması oluşturun veya mevcut bir projeyi açın. 
3. **Project** > **Manage NuGet Packages...** yolunu izleyin. 
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Metin alanına *Aspose.Slides* yazın. 
5. **Aspose.Slides for .NET** üzerine tıklayın ve ardından **Add Package**'a tıklayın. 
6. Basit bir kod parçacığı ekleyin. 
   * [bu sayfadaki](/slides/tr/net/create-presentation/) kodu kopyalayabilirsiniz. 
7. Uygulamayı çalıştırın. 
8. Projenizin *folder/bin/Debug/presentation_file_name* klasörünü açın. 

## **SSS**

**Ücretsiz bir sürüm veya deneme sınırlaması var mı?**

Evet, varsayılan olarak Aspose.Slides değerlendirme modunda çalışır; bu mod, filigran ekler ve başka sınırlamalar içerebilir. Kısıtlamaları kaldırmak için geçerli bir [lisans](/slides/tr/net/licensing/) uygulamanız gerekir.