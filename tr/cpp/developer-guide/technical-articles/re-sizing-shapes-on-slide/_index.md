---
title: Sunum Slaytlarındaki Şekilleri Yeniden Boyutlandır
type: docs
weight: 100
url: /tr/cpp/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandırma
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Aspose.Slides for C++ müşterilerinin en sık sorduğu sorulardan biri, slayt boyutu değiştiğinde verinin kesilmesini önlemek için şekillerin nasıl yeniden boyutlandırılacağıdır. Bu kısa teknik makale bu işlemin nasıl yapılacağını gösterir.

## **Şekilleri Yeniden Boyutlandır**

Slayt boyutu değiştiğinde şekillerin hizalanmasını kaybetmesini önlemek için, her bir şeklin konum ve boyutlarını yeni slayt düzenine uygun şekilde güncelleyin.

```cpp
// Sunum dosyasını yükle.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Orijinal slayt boyutunu al.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Mevcut şekilleri ölçeklendirmeden slayt boyutunu değiştir.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Yeni slayt boyutunu al.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Her slaytta şekilleri yeniden boyutlandır ve konumlandır.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Şeklin boyutunu ölçekle.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Şeklin konumunu ölçekle.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
Bir slayt bir tablo içeriyorsa, yukarıdaki kod doğru şekilde çalışmaz. Bu durumda tablodaki her hücre yeniden boyutlandırılmalıdır.
{{% /alert %}} 

Tabloları içeren slaytları yeniden boyutlandırmak için aşağıdaki kodu kullanın. Tablolar için genişlik veya yükseklik ayarlamak özel bir durumdur: tablonun genel boyutunu değiştirmek için her bir satır yüksekliğini ve sütun genişliğini ayrı ayrı ayarlamanız gerekir.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Orijinal slayt boyutunu al.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Mevcut şekilleri ölçeklendirmeden slayt boyutunu değiştir.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Yeni slayt boyutunu al.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Şekil boyutunu ölçekle.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Şekil konumunu ölçekle.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Şekil boyutunu ölçekle.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Şekil konumunu ölçekle.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Şekil boyutunu ölçekle.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Şekil konumunu ölçekle.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Bir slaytı yeniden boyutlandırdıktan sonra şekiller neden bozulur veya kesilir?**  

Bir slaytı yeniden boyutlandırırken, şekiller ölçek açıkça değiştirilmedikçe orijinal konum ve boyutlarını korur. Bu, içeriğin kırpılmasına veya şekillerin hizalanmamasına neden olabilir.

**Sağlanan kod tüm şekil türleri için çalışıyor mu?**  

Temel örnek çoğu şekil türü (metin kutuları, görseller, grafikler vb.) için çalışır. Ancak tablolar için satır ve sütunları ayrı ayrı ele almanız gerekir; çünkü bir tablonun yüksekliği ve genişliği, bireysel hücrelerin boyutlarıyla belirlenir.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**  

Tablonun tüm satır ve sütunları üzerinden döngü oluşturup, yüksekliğini ve genişliğini orantılı olarak yeniden boyutlandırmalısınız; ikinci kod örneğinde gösterildiği gibi.

**Bu yeniden boyutlandırma ana slaytlar ve yerleşim slaytları için çalışır mı?**  

Evet, ancak tutarlılığı sağlamak için [Masters](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_masters/) ve [Layout slides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_layoutslides/) üzerinden de döngü oluşturup aynı ölçeklendirme mantığını şekillerine uygulamalısınız.

**Yeniden boyutlandırma ile birlikte bir slaytın yönünü (dikey/yatay) değiştirebilir miyim?**  

Evet. Yönü değiştirmek için [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidesize/set_orientation/) yöntemini kullanabilirsiniz. Düzeni korumak için ölçekleme mantığını buna göre ayarladığınızdan emin olun.

**Ayarlayabileceğim slayt boyutu için bir limit var mı?**  

Aspose.Slides özelleştirilmiş boyutları destekler, ancak çok büyük boyutlar performansı etkileyebilir veya bazı PowerPoint sürümleriyle uyumluluk sorunları yaratabilir.

**Sabit en‑boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**  

Şeklin `get_AspectRatioLocked` metodunu kontrol edin. Oran kilitli ise, genişlik ve yüksekliği bireysel olarak ölçeklendirmek yerine orantılı olarak ayarlayın.