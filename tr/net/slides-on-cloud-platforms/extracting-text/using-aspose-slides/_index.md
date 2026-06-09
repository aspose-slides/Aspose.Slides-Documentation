---
title: "Aspose.Slides ile PPT, PPTX ve ODP'den Metin Çıkarma"
linktitle: Slaytlar
type: docs
weight: 30
url: /tr/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- bulut platformları
- bulut entegrasyonu
- metin çıkarma
- metin çıkar
- PPT
- PPTX
- ODP
- sunum dosyaları
- çapraz platform
- Office bağımsız
- notlar ve yorumlar
- kurumsal indeksleme
- veri zenginleştirme
- .NET
- Aspose.Slides
description: "Aspose.Slides API'lerini kullanarak popüler bulut platformlarında sunumlardan metin çıkarın, PPT, PPTX ve ODP için aramayı, analizi ve dışa aktarmayı otomatikleştirin."
---
## **Giriş**

Aspose.Slides, **güçlü, yüksek seviyeli bir API** sağlayarak **PPT, PPTX ve ODP** dahil sunum dosyalarından metin çıkarmayı mümkün kılar. Sadece PPTX'i destekleyen ve karmaşık XML ayrıştırması gerektiren Open XML SDK'nın aksine, Aspose.Slides metin çıkarmayı basitleştirir ve çıkarılan içeriği iş akışlarınıza entegre etmeye odaklanmanızı sağlar.

## **PresentationFactory.Instance.GetPresentationText ile Hızlı Metin Çıkarma**

Bir sunumdan metin çıkarmak için **Aspose.Slides API**'si, statik yöntem `PresentationFactory.Instance.GetPresentationText`'i sunar. Bu yöntem, bir sunum dosyası ya da veri akışı ile çalışmak için birden fazla aşırı yükleme içerir ve **slaytlardan, ana slaytlardan, düzenlerden, notlardan ve yorumlardan** metin yakalar. Çıkarılan metne `IPresentationText` arayüzü üzerinden erişilir.

```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```

## **GetPresentationText için Çalışma Modları**

`PresentationFactory` içinde yer alan `GetPresentationText` yöntemi, çıktıda metnin nasıl düzenlendiğini kontrol eden `TextExtractionArrangingMode` parametresi ile metin çıkarmayı ince ayar yapmanıza olanak tanır.

### **Mevcut Modlar**

- **TextExtractionArrangingMode.Unarranged** – Metni serbest bir biçimde, özgün slayt düzenini göz ardı ederek çıkarır.  
- **TextExtractionArrangingMode.Arranged** – Metin sırasını her slayttaki konumuna göre korur.  

```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```

## **PresentationFactory Yöntemlerinin Temel Avantajları**

- **Tüm Sunumları Yüklemeye Gerek Yok**: Bellek tüketimini en aza indirir ve işlem hızını artırır.  
- **Büyük Dosyalar İçin Optimize Edilmiş**: Önemli boyuttaki sunumları bile verimli bir şekilde işler, metni hızlıca çıkarır.  
- **Notları ve Yorumları Alır**: Kapsamlı içerik kapsama sağlamak için kullanıcı ek açıklamalarını içerir.  
- **Dizleme ve İçerik Analizi İçin İdeal**: Otomatik işleme ve veri zenginleştirme gerektiren kurumsal sistemler için mükemmeldir.  
- **Office Bağımsız**: Microsoft PowerPoint yüklü olmadan çalışır, tamamen bağımsız bir çözüm sunar.  
- **Çoklu Format Desteği**: **PPT, PPTX ve ODP** ile sorunsuz çalışır.  
- **Esnek, Güçlü API**: Yapılandırılmış metin çıkarmak için çok yönlü yöntemler sunar.  
- **Tam Slayt Kapsamı**: **düzenlerden, ana slaytlardan, standart slaytlardan, arka planlardan, konuşmacı notlarından ve yorumlardan** metin çıkarır.  
- **Çapraz Platform Uyumluluğu**: **Windows, Linux, macOS** ve bulut ortamlarında çalışır.  
- **Yüksek Performans ve Ölçeklenebilirlik**: **SaaS uygulamaları** ve büyük ölçekli kurumsal dağıtımlar için uygundur.  

## **Desteklenen İşletim Sistemleri**

Aspose.Slides, çeşitli işletim sistemlerinde çalışır:

- **Windows** (ör. Windows 7, 8, 10, 11 ve Server sürümleri)  
- **Linux** (Ubuntu, Debian, Fedora, CentOS vb. dahil olmak üzere çeşitli dağıtımlar)  
- **macOS** (10.15 Catalina ve sonrasındaki modern sürümler dahil)  

## **Desteklenen Programlama Dilleri**

Aspose.Slides birden fazla platform ve dille entegre olur:

- **C#** – Öncelikle Aspose.Slides for .NET üzerinden desteklenir.  
- **Java** – Aspose.Slides for Java ile tam özellikli API mevcuttur.  
- **C++** – Performans kritik C++ uygulamaları için Aspose.Slides kullanılabilir.  
- **Python via .NET** – .NET bütünleşmesi kullanarak Aspose.Slides işlevselliğini entegre edin.  
- **Diğer .NET Uyumlu Diller** – Kütüphaneyi .NET tarafından desteklenen herhangi bir ortamda kullanın.  

## **Sonuç**

Aspose.Slides, Open XML SDK ile karşılaştırıldığında **çeşitli dosya formatları, sezgisel metin yapılandırması ve basit uygulama** destekleyerek PowerPoint ve OpenDocument sunumları için **kapsamlı metin çıkarımı** sunar. **Slaytlardan ve notlardan şablon içeriğine** kadar, **Aspose.Slides** sunum metnini çıkarmak ve yönetmek için yüksek verimli, özellik açısından zengin bir çözümdür.