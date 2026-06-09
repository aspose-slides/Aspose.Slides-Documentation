---
title: .NET'te Sunumlarda SmartArt Grafiklerini Yönetme
linktitle: SmartArt Grafikleri
type: docs
weight: 20
url: /tr/net/manage-smartart-shape/
keywords:
- SmartArt nesnesi
- SmartArt grafiği
- SmartArt stili
- SmartArt rengi
- SmartArt oluştur
- SmartArt ekle
- SmartArt düzenle
- SmartArt değiştir
- SmartArt eriş
- SmartArt düzen türü
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET'te PowerPoint SmartArt oluşturma, düzenleme ve stil verme işlemlerini otomatikleştirin; özlü kod örnekleri ve performansa odaklı rehberlik sunar."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında SmartArt grafiklerini programlı olarak oluşturmanıza ve yönetmenize olanak tanır. Bu makale, bir slayda SmartArt şekli eklemeyi, mevcut SmartArt şekillerine erişmeyi, belirli bir düzen türüne göre SmartArt bulmayı ve SmartArt stilini veya renk stilini değiştirerek görsel görünümünü güncellemeyi açıklar.

Örnekler, sunum slaytının şekil koleksiyonu üzerinden SmartArt şekilleriyle nasıl çalışılacağını, bir şeklin SmartArt olup olmadığını kontrol etmeyi ve ardından özelliklerini değiştirmeyi ya da incelemeyi göstermektedir.

## **SmartArt Şekli Oluşturma**
Aspose.Slides for .NET artık slaytlarına sıfırdan özel SmartArt şekilleri eklemeyi kolaylaştırıyor. Aspose.Slides for .NET, SmartArt şekilleri oluşturmak için en basit API'yi sunmuştur. Bir slayta SmartArt şekli oluşturmak için lütfen aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının örneğini oluşturun.
- Bir slaydın referansını, İndeksini kullanarak edinin.
- LayoutType'ını ayarlayarak bir SmartArt şekli ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```c#
// Sunumu oluşturun
using (Presentation pres = new Presentation())
{
 
    // Sunum slaytına erişin
    ISlide slide = pres.Slides[0];
 
    // Smart Art şekli ekle
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
 
    // Sunumu kaydediyor
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Bir Slayttaki SmartArt Şekline Erişme**
Aşağıdaki kod, sunum slaytına eklenen SmartArt şekillerine erişmek için kullanılacaktır. Örnek kodda, slayt içindeki her şekli dolaşacak ve şeklin SmartArt olup olmadığını kontrol edeceğiz. Eğer şekil SmartArt tipindeyse, onu SmartArt örneğine tip dönüştüreceğiz.

```c#
// İstenen sunumu yükle
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // İlk slayttaki her şekli dolaşın
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol edin
        if (shape is ISmartArt)
        {
            // Şekli SmartArtEx tipine dönüştür
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```

## **Belirli Bir Düzen Türüne Sahip SmartArt Şekline Erişme**
Aşağıdaki örnek kod, belirli bir LayoutType'a sahip SmartArt şekline erişmeye yardımcı olur. Lütfen LayoutType'ın yalnızca okunabilir olduğunu ve yalnızca SmartArt şekli eklenirken ayarlandığını, dolayısıyla değiştirilemeyeceğini unutmayın.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
- İlk slaydın referansını, İndeksini kullanarak edinin.
- İlk slayttaki her şekli dolaşın.
- Şeklin SmartArt tipinde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt tipine dönüştürün.
- Belirli LayoutType'a sahip SmartArt şekli kontrol edin ve ardından gerekli işlemleri gerçekleştirin.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // İlk slayttaki her şekli dolaşın
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol edin
        if (shape is ISmartArt)
        {
            // Şekli SmartArtEx tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt düzeni kontrol ediliyor
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```

## **SmartArt Şekli Stilini Değiştirme**
Aşağıdaki örnek kod, belirli bir LayoutType'a sahip SmartArt şekline erişmeye yardımcı olur.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
- İlk slaydın referansını, İndeksini kullanarak edinin.
- İlk slayttaki her şekli dolaşın.
- Şeklin SmartArt tipinde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt tipine dönüştürün.
- Belirli bir Stil ile SmartArt şekli bulun.
- SmartArt şekli için yeni Stili ayarlayın.
- Sunumu kaydedin.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // İlk slayttaki her şekli dolaşın
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol edin
        if (shape is ISmartArt)
        {
            // Şekli SmartArtEx tipine dönüştür
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt stilini kontrol ediliyor
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // SmartArt stili değiştiriliyor
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Sunumu kaydediyor
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```

## **SmartArt Şekli Renk Stilini Değiştirme**
Bu örnekte, herhangi bir SmartArt şeklinin renk stilini değiştirmeyi öğreneceğiz. Aşağıdaki örnek kod, belirli bir renk stiline sahip SmartArt şekline erişecek ve stilini değiştirecektir.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
- İlk slaydın referansını, İndeksini kullanarak edinin.
- İlk slayttaki her şekli dolaşın.
- Şeklin SmartArt tipinde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt tipine dönüştürün.
- Belirli bir Renk Stili ile SmartArt şekli bulun.
- SmartArt şekli için yeni Renk Stilini ayarlayın.
- Sunumu kaydedin.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // İlk slayttaki her şekli dolaşın
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol edin
        if (shape is ISmartArt)
        {
            // Şekli SmartArtEx tipine dönüştür
            ISmartArt smart = (ISmartArt)shape;

            // SmartArt renk türü kontrol ediliyor
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // SmartArt renk türü değiştiriliyor
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Sunumu kaydediyor
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**SmartArt'ı tek bir nesne olarak animasyonlandırabilir miyim?**

Evet. SmartArt bir şekildir, bu nedenle diğer şekillerde olduğu gibi animasyon API'si aracılığıyla [standart animasyonlar](/slides/tr/net/powerpoint-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulayabilirsiniz.

**Bir slaytta belirli bir SmartArt'ı iç kimliğini bilmiyorsam nasıl bulabilirim?**

Alternatif Metni (AltText) ayarlayın ve kullanın, ardından şekli bu değerle arayın—bu, hedef şekli bulmanın önerilen bir yoludur.

**SmartArt'ı diğer şekillerle gruplandırabilir miyim?**

Evet. SmartArt'ı diğer şekillerle (resimler, tablolar vb.) gruplandırabilir ve ardından [grubu manipüle edebilirsiniz](/slides/tr/net/group/).

**Belirli bir SmartArt'ın görüntüsünü nasıl alabilirim (ör. önizleme veya rapor için)?**

Şeklin bir küçük resim/görüntüsünü dışa aktarın; kütüphane, [bireysel şekilleri](/slides/tr/net/create-shape-thumbnails/) raster dosyalara (PNG/JPG/TIFF) render edebilir.

**Sunumun tamamını PDF'e dönüştürdüğümde SmartArt görünümü korunur mu?**

Evet. Renderleme motoru, [PDF dışa aktarımı](/slides/tr/net/convert-powerpoint-to-pdf/) için yüksek doğruluk hedefler ve çeşitli kalite ve uyumluluk seçenekleri sunar.