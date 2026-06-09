---
title: Metin Kutusu
type: docs
weight: 40
url: /tr/java/examples/elements/text-box/
keywords:
- kod örneği
- metin kutusu
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da metin kutularıyla çalışın: PPT, PPTX ve ODP sunumları için Java kullanarak metni ekleyin, biçimlendirin, hizalayın, satır içine alın, otomatik sığdırın ve stil verin."
---
Aspose.Slides'ta bir **metin kutusu** `AutoShape` ile temsil edilir. Neredeyse tüm şekiller metin içerebilir, ancak tipik bir metin kutusunun dolgu veya kenarlığı yoktur ve yalnızca metin gösterir.

Bu kılavuz, metin kutularını programlı olarak ekleme, erişme ve kaldırma yöntemlerini açıklar.

## **Metin Kutusu Ekle**

Bir metin kutusu yalnızca dolgu ve kenarlığı olmayan ve biçimlendirilmiş metin içeren bir `AutoShape`'dir. İşte bir tane nasıl oluşturulur:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Bir dikdörtgen şekil oluştur (varsayılan olarak kenarlıklı, dolu ve metinsiz).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Dolgu ve kenarlığı kaldırarak tipik bir metin kutusu gibi görünmesini sağla.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Metin biçimlendirmesini ayarla.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Gerçek metin içeriğini ata.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Not:** Boş olmayan bir `TextFrame` içeren herhangi bir `AutoShape` metin kutusu olarak işlev görebilir.

## **İçeriğe Göre Metin Kutularına Erişim**

Belirli bir anahtar kelimeyi (ör. "Slide") içeren tüm metin kutularını bulmak için şekiller üzerinde döngü yapın ve metinlerini kontrol edin:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Yalnızca AutoShape'ler düzenlenebilir metin içerebilir.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Eşleşen metin kutusuyla bir şey yap.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **İçeriğe Göre Metin Kutularını Kaldır**

Bu örnek, belirli bir anahtar kelimeyi içeren ilk slayttaki tüm metin kutularını bulur ve siler:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **İpucu:** Döngü sırasında koleksiyonu değiştirmeden önce şekil koleksiyonunun bir kopyasını oluşturun; bu sayede koleksiyon değiştirme hatalarını önlersiniz.