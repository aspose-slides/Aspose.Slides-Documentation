---
title: C++'ta Sunumlardan Paragraf Sınırlarını Al
linktitle: Paragraf Sınırları
type: docs
weight: 43
url: /tr/cpp/paragraph-bounds/
keywords:
- paragraf sınırları
- paragraf koordinatı
- paragraf boyutu
- metin çerçevesi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde paragraf sınırlarını alarak PowerPoint sunumlarında metin konumlandırmayı nasıl optimize edeceğinizi öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde paragrafların sınırlarını, boyutunu ve koordinatlarını nasıl alacağınızı açıklar. [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) kullanarak bir paragraf dikdörtgenini [IParagraph::GetRect](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/getrect/) ile nasıl alabileceğinizi, tablo hücresi metin çerçevesindeki paragraf koordinatlarını nasıl elde edebileceğinizi gösterir ve ölçü birimleri, metin kaydırmanın sınırlar üzerindeki etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli detayları vurgular.

## **Paragrafın Dikdörtgen Koordinatlarını Al**

[IParagraph::GetRect](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/getrect/) kullanarak bir paragrafın sınırlayıcı dikdörtgenini alın.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Tablo Hücresi Metin Çerçevesi İçindeki Bir Paragrafın Boyutunu Al**

Bir tablo hücresi metin çerçevesindeki [IParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/) öğesinin boyutunu ve koordinatlarını almak için [IParagraph::GetRect](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/getrect/) kullanın. Döndürülen dikdörtgen tablo hücresi metin çerçevesine göre görecelidir; slayt düzeyinde koordinatlara ihtiyacınız olduğunda tablo konumunu ve hücre offsetini ekleyin.

Aşağıdaki örnek, bir tablo hücresi içinde paragraf sınırlarını alır ve bu sınırları görselleştirmek için slayta dikdörtgenler çizer:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Paragraf koordinatları hangi birimlerde ölçülür?**

Puan (point) biriminde ölçülürler; 1 inç 72 puana eşittir. Bu, slayttaki tüm koordinat ve boyutlar için geçerlidir.

**Kelime kaydırma bir paragrafın sınırlarını etkiler mi?**

Evet. [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) için [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_wraptext/) etkinleştirildiğinde, metin alan genişliğine uyacak şekilde bölünür ve bu da paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları dışa aktarılan görüntüde piksellere güvenilir bir şekilde eşlenebilir mi?**

Evet. Puanları piksellere bu formülle dönüştürün: piksel = puan x (DPI / 72). Sonuç, render veya dışa aktarım için seçilen DPI'ye bağlıdır.

**Stil mirasını dikkate alarak “etkili” paragraf biçimlendirme parametrelerini nasıl alırım?**

[effective paragraph formatting data structure](/slides/tr/cpp/shape-effective-properties/) kullanın; girintiler, satır aralıkları, kaydırma, RTL ve daha fazlası için nihai birleştirilmiş değerleri döndürür.