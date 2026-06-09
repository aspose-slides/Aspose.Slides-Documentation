---
title: C++'ta Sunumlardan Paragraf Sınırlarını Almak
linktitle: Paragraf
type: docs
weight: 60
url: /tr/cpp/paragraph/
keywords:
- paragraf sınırları
- metin bölümü sınırları
- paragraf koordinatı
- bölüm koordinatı
- paragraf boyutu
- metin bölümü boyutu
- metin çerçevesi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta paragraf ve metin bölümü sınırlarını alarak PowerPoint sunumlarında metin konumlandırmasını optimize etmeyi öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde paragrafların ve metin bölümlerinin sınırlamalarını, boyutlarını ve koordinatlarını nasıl alacağınızı açıklar. `GetRect()` kullanarak bir `TextFrame` içindeki paragrafın dikdörtgenini nasıl alacağınızı, bir tablo hücresi metin çerçevesi içinde paragraf ve bölüm koordinatlarını nasıl elde edeceğinizi gösterir ve ölçüm birimleri, metin kaydırmanın sınırlara etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli detayları vurgular.

## **TextFrame içinde Paragraf ve Bölüm Koordinatlarını Alma**
Aspose.Slides for C++ kullanarak geliştiriciler artık bir TextFrame'in paragraf koleksiyonundaki Paragraf için dikdörtgen koordinatlarını alabilirler. Ayrıca bir paragraftaki bölüm koleksiyonundaki bölümün koordinatlarını almanıza da olanak tanır. Bu konuda, bir örnek yardımıyla paragrafın dikdörtgen koordinatlarını ve paragraf içindeki bölümün konumunu nasıl alacağınızı göstereceğiz.

## **Paragrafın Dikdörtgen Koordinatlarını Alma**
Yeni **GetRect()** yöntemi eklendi. Bu, paragraf sınırları dikdörtgenini almanıza olanak tanır.

``` cpp
// Bir sunum dosyasını temsil eden Presentation nesnesi oluşturulur
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Bir Tablo Hücresi TextFrame içinde Paragraf ve Bölüm Boyutunu Alma**
Bir tablo hücresi metin çerçevesinde [Bölüm](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.portion) veya [Paragraf](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.paragraph) boyutunu ve koordinatlarını elde etmek için [IPortion::GetRect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) ve [IParagraph::GetRect](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t) yöntemlerini kullanabilirsiniz.

Bu örnek kod, açıklanan işlemi gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **SSS**

**Paragraflar ve metin bölümleri için döndürülen koordinatlar hangi birimlerde ölçülür?**

Puan (point) cinsinden, 1 inç = 72 puan. Bu, slayttaki tüm koordinat ve boyutlar için geçerlidir.

**Kelime kaydırma bir paragrafın sınırlarını etkiler mi?**

Evet. Eğer [kaydırma](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframeformat/set_wraptext/) [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframe/) içinde etkinleştirilmişse, metin alan genişliğine uyması için bölünür ve bu, paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları dışa aktarılan görüntüde piksellere güvenilir bir şekilde eşlenebilir mi?**

Evet. Puanları piksellere şu şekilde dönüştürün: piksel = puan × (DPI / 72). Sonuç, rendering/dışa aktarma için seçilen DPI'ye bağlıdır.

**Stil kalıtımını göz önünde bulundurarak “etkili” paragraf biçimlendirme parametrelerini nasıl alırım?**

[etkili paragraf biçimlendirme veri yapısı](/slides/tr/cpp/shape-effective-properties/) kullanın; girinti, aralık, kaydırma, RTL ve daha fazlası için nihai birleştirilmiş değerleri döndürür.