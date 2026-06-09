---
title: Kurulum
type: docs
weight: 70
url: /tr/cpp/installation/
keywords:
- Aspose.Slides'ı kurun
- Aspose.Slides'ı indirin
- Aspose.Slides'ı kullanın
- Aspose.Slides kurulumu
- Windows
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ı hızlı bir şekilde nasıl kuracağınızı öğrenin. Adım adım kılavuz, sistem gereksinimleri ve kod örnekleri — bugün PowerPoint sunumlarıyla çalışmaya başlayın!"
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ı Windows'ta nasıl kuracağınızı açıklar. NuGet tabanlı kurulum üzerine odaklanır ve Windows'ta NuGet Paket Yöneticisi veya Paket Yöneticisi Konsolu aracılığıyla kütüphaneyi bir Visual Studio projesine eklemenin nasıl yapılacağını gösterir. Ayrıca paketi güncelleme ve gerektiğinde ön sürüm derlemelerini kurma yöntemlerini de açıklar.

## **Windows**
NuGet, PC'lerde C++ için Aspose API'lerini indirip kurmanın en kolay yolunu sağlar. 

### **Seçenek Bir: NuGet Paket Yöneticisi'nden Aspose.Slides for C++'ı Yükleyin veya Güncelleyin**

1. Microsoft Visual Studio'yu açın. 
2. Basit bir konsol uygulaması oluşturun. Ya da tercih ettiğiniz projeyi açabilirsiniz. 
3. **Tools** > **NuGet package manager** menüsüne gidin.
4. **Browse** altında, metin alanına *Aspose.Slides.Cpp* yazın. 

![todo:image_alt_text](installation_1.png)

3. İhtiyacınız olan **Aspose.Slides.Cpp** sürümüne tıklayın ve ardından **Install**'a tıklayın. 
   * Aspose.Slides'ı güncellemek istiyorsanız—zaten yüklü olduğu anlamına gelir—**Update**'a tıklayın. 

Seçilen API indirilir ve projenize referans olarak eklenir.

### **Seçenek 2: Paket Yöneticisi Konsolu Üzerinden Aspose.Slides'ı Yükleyin veya Güncelleyin**

Paket yöneticisi konsolunu kullanarak [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) referans göstermek için şu adımları izleyin:

1. Visual Studio'da çözümünüzü/projenizi açın.

1. **Tools** > **NuGet Package Manager** > **Package Manager Console** menüsüne gidin. 

Paket Yöneticisi Konsolu açılır. 

![todo:image_alt_text](installation_2.png)

4. Bu komutu yazın: `Install-Package Aspose.Slides.Cpp` 
> x86 sürümünü kurmak istiyorsanız, Aspose.Slides.Cpp.x86 paketini kullanın: `Install-Package Aspose.Slides.Cpp.x86`

5. Enter tuşuna basın.

En son tam sürüm uygulamanıza kurulur. 

* Alternatif olarak, komuta `-prerelease` son ekini ekleyerek en son sürümün (hotfix'ler dahil) kurulmasını belirtebilirsiniz.

![todo:image_alt_text](installation_3.png)

​İndirme tamamlandığında, bazı onay mesajları görmelisiniz.  

![todo:image_alt_text](installation_4.png)

Eğer [Aspose EULA](https://about.aspose.com/legal/eula)'ı tanımıyorsanız, URL'de referans verilen lisansı okumak isteyebilirsiniz.  

Paket Yöneticisi Konsolu'nda, Aspose.Slides paketindeki güncellemeleri kontrol etmek için `Update-Package Aspose.Slides.Cpp` komutunu çalıştırabilirsiniz. Güncellemeler (bulunursa) otomatik olarak kurulur. Ayrıca en son sürümü güncellemek için `-prerelease` son ekini de kullanabilirsiniz.


### **Include ve lib Klasörlerini Kullanma**
1. En son Aspose.Slides for C++ sürümünü [Download](https://downloads.aspose.com/slides/tr/cpp) edin.
1. Klasörü üretim ortamına çıkarın.
1. Aspose.Slides for C++'ı kullanmak için projenizde Include ve lib klasörlerine referans gösterin

## **FAQ**

**Ücretsiz bir sürüm veya deneme sınırlaması var mı?**

Evet, varsayılan olarak Aspose.Slides değerlendirme modunda çalışır; bu mod su işareti ekler ve başka sınırlamalar içerebilir. Kısıtlamaları kaldırmak için geçerli bir [license](/slides/tr/cpp/licensing/) uygulamanız gerekir.