---
title: PHP ile Sunumlardan Paragraf Sınırlarını Al
linktitle: Paragraf Sınırları
type: docs
weight: 43
url: /tr/php-java/paragraph-bounds/
keywords:
- paragraf sınırları
- paragraf koordinatı
- paragraf boyutu
- metin çerçevesi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint sunumlarında metin konumlandırmasını optimize etmek için Java üzerinden PHP için Aspose.Slides içinde paragraf sınırlarını nasıl alacağınızı öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde paragrafların sınırlarını, boyutlarını ve koordinatlarını nasıl alacağınızı açıklar. [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) üzerinden [Paragraph::getRect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/getrect/) kullanarak bir paragraf dikdörtgeni nasıl alınacağını, tablo hücresi metin çerçevesi içinde paragraf koordinatlarının nasıl elde edileceğini ve ölçüm birimleri, satır kaydırmanın sınırlar üzerindeki etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli ayrıntıları vurgular.

## **Paragrafın Dikdörtgen Koordinatlarını Al**

Bir paragrafın sınırlayıcı dikdörtgenini almak için [Paragraph::getRect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/getrect/) kullanın.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **Tablo Hücresi TextFrame İçindeki Paragrafın Boyutunu Al**

Bir tablo hücresi metin çerçevesindeki [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) boyutunu ve koordinatlarını almak için [Paragraph::getRect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/getrect/) kullanın. Döndürülen dikdörtgen, tablo hücresi metin çerçevesine göre görecelidir, bu yüzden slayt düzeyinde koordinatlara ihtiyacınız olduğunda tablo konumunu ve hücre offset'ini ekleyin.

Aşağıdaki örnek, bir tablo hücresi içinde paragraf sınırlarını alır ve bu sınırları görselleştirmek için slayta dikdörtgenler çizer:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Paragraf koordinatları hangi birimlerde ölçülür?**

Paragraf koordinatları puan (point) cinsinden ölçülür; 1 inç 72 puana eşittir. Bu, slayttaki tüm koordinat ve boyutlar için geçerlidir.

**Kelime kaydırma bir paragrafın sınırlarını etkiler mi?**

Evet. [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/setwraptext/) [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) için etkinleştirildiğinde, metin alan genişliğine sığacak şekilde bölünür ve bu da paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları, dışa aktarılan görüntüde piksellere güvenilir şekilde eşlenebilir mi?**

Evet. Puanları piksellere bu formülle dönüştürün: pikseller = puanlar x (DPI / 72). Sonuç, renderleme veya dışa aktarma için seçilen DPI'ye bağlıdır.

**Stil kalıtımı göz önüne alınarak "etkili" paragraf biçimlendirme parametrelerini nasıl alırım?**

[effective paragraph formatting data structure](/slides/tr/php-java/shape-effective-properties/) kullanın; girinti, boşluk, kaydırma, RTL ve diğerleri için nihai birleştirilmiş değerleri döndürür.