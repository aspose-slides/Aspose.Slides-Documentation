---
title: JavaScript'te PowerPoint Metin Paragraflarını Yönetme
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
  - metin ekle
  - paragraf ekle
  - metni yönet
  - paragrafları yönet
  - madde işaretlerini yönet
  - paragraf girintisi
  - sarkıt girinti
  - paragraf madde işareti
  - numaralı liste
  - madde işaretli liste
  - paragraf özellikleri
  - HTML içe aktar
  - metni HTML'ye dönüştür
  - paragrafı HTML'ye dönüştür
  - paragrafı görüntüye dönüştür
  - metni görüntüye dönüştür
  - paragrafı dışa aktar
  - PowerPoint
  - sunum
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile JavaScript'te paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görüntüleri oluşturmayı ve biçimlendirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, metni metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) şekil içindeki metin kapsayıcısını temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) bir metin çerçevesindeki bir paragrafı temsil eder ve bölümlerine ve paragraf seviyesindeki biçimlendirmeye erişim sağlar.
* [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) bir paragraftaki metin yürütmesini temsil eder. Her bölüm kendi metnine ve karakter seviyesindeki biçimlendirmeye sahip olabilir.

Bu nedenle bir paragraf, birden çok bölüm kullanarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmelere sahip metin içerebilir.

## **Paragrafları Oluşturma ve Biçimlendirme**

### **Birden Çok Bölüm ile Paragraflar Oluşturma**

Aşağıdaki adımlar üç paragraf içeren bir metin çerçevesi oluşturur; her paragrafta üç bölüm bulunur:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slayta indeks üzerinden erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin.
5. Varsayılan paragrafı kullanın ve metin çerçevesine iki adet daha [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) nesnesi ekleyin.
6. Her paragrafın üç bölüm içerecek şekilde yeterli sayıda [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) nesnesi ekleyin. Varsayılan paragraf zaten bir boş bölüm içeriyor.
7. Her bölümün metnini ayarlayın.
8. [Portion.getPortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/getportionformat/) aracılığıyla karakter seviyesinde biçimlendirme uygulayın.
9. Değiştirilmiş sunumu kaydedin.

Bu JavaScript örneği adımları uygular:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Madde İşaretli ve Numaralı Listeler**

### **Madde İşaretli veya Numaralı Liste Oluşturma**

Madde işaretleri ve numaralar, ilgili öğelerin taranmasını kolaylaştırır. Aspose.Slides'te, liste ayarları [BulletFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bulletformat/) aracılığıyla tanımlanır.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slayta indeks üzerinden erişin.
3. Seçilen slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin.
5. Metin çerçevesinden varsayılan paragrafı kaldırın.
6. Sembol madde işareti için bir [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) oluşturun.
7. [BulletFormat.setType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bulletformat/settype/) değerini [BulletType.Symbol](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bullettype/) olarak ayarlayın ve madde işareti karakterini belirtin.
8. Paragraf metnini, girintiyi, madde işareti rengini ve yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. İkinci bir paragraf oluşturup [BulletFormat.setType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bulletformat/settype/) değerini [BulletType.Numbered](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bullettype/) olarak ayarlayın.
11. Numaralı madde işareti stilini yapılandırın ve paragrafı metin çerçevesine ekleyin.
12. Sunumu kaydedin.

Bu JavaScript örneği bir sembol madde işareti ve bir numaralı madde işareti oluşturur:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Resim Madde İşaretleri Kullanma**

Resim madde işaretleri, sembol veya sayı yerine özel bir görsel kullanmanıza izin verir.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slayta indeks üzerinden erişin.
3. Bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin ve onun [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin.
4. Metin çerçevesinden varsayılan paragrafı kaldırın.
5. Madde işareti görselini yükleyin ve sunumun resim koleksiyonuna [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) olarak ekleyin.
6. Bir [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) oluşturun ve metnini ayarlayın.
7. [BulletFormat.setType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bulletformat/settype/) değerini [BulletType.Picture](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bullettype/) olarak ayarlayın.
8. [BulletFormat.getPicture](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bulletformat/getpicture/) aracılığıyla görseli atayın ve madde işareti yüksekliğini ayarlayın.
9. Paragrafı metin çerçevesine ekleyin.
10. Değiştirilmiş sunumu kaydedin.

Bu JavaScript örneği bir resim madde işareti oluşturur:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Çok Seviyeli Liste Oluşturma**

[ParagraphFormat.setDepth] değerini ayarlayarak paragrafları bir listenin farklı seviyelerine yerleştirin. Üst seviye derinliği `0`'dır.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) oluşturun ve bir slayta erişin.
2. Bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin ve metin çerçevesindeki varsayılan paragrafı temizleyin.
3. Dört paragraf oluşturun ve madde işareti sembollerini yapılandırın.
4. [ParagraphFormat.setDepth] değerlerini `0`, `1`, `2` ve `3` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu JavaScript örneği dört seviyeli bir madde işaretli liste oluşturur:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Numaralı Liste Öğelerini Özel Değerlerle Başlatma**

[BulletFormat.setNumberedBulletStartWith] kullanarak numaralı bir paragraf için gösterilecek başlangıç sayısını ayarlayın.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) oluşturun ve bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
2. Şeklin metin çerçevesinden varsayılan paragrafı temizleyin.
3. Üç numaralı paragraf oluşturun.
4. [BulletFormat.setNumberedBulletStartWith] değerini ilgili paragraflar için sırasıyla `2`, `3` ve `7` olarak ayarlayın.
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu JavaScript örneği her paragraf için özel bir başlangıç sayısı atar:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Paragraf Düzeni ve Son Özelliklerini Kontrol Etme**

### **İlk Satır Girintisi Ayarlama**

[ParagraphFormat.setIndent] kullanarak bir paragrafın ilk satır girintisini kontrol edin. Bu yöntem, yalnızca paragrafın sol kenar boşluğuna göre ilk satırı hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalanmış kalır.

Tüm paragrafı taşımak gerektiğinde [ParagraphFormat.setMarginLeft] kullanın. Yalnızca ilk satırı taşımak istediğinizde [ParagraphFormat.setIndent] kullanın.

Aşağıdaki örnek birkaç paragraf oluşturur ve farklı [ParagraphFormat.setIndent] değerleri uygulayarak ilk satır girintisinin paragraf düzenini nasıl etkilediğini gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Birkaç paragraf oluşturun ve onlar için farklı [ParagraphFormat.setIndent] değerleri ayarlayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilmiş sunumu kaydedin.

Bu kod bir paragraf girintisi nasıl ayarlanır gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragrafların ilk satır girintisi](first_line_indent.png)

### **Sarkıt Girinti Ayarlama**

Sarkıt girinti, ilk satırın kalan satırların solundan başladığı bir paragraf düzenidir. Aspose.Slides'te bu etkiyi [ParagraphFormat.setIndent] ile oluşturursunuz. İlk satırı paragraf gövdesine göre sola kaydırmak için negatif bir değer geçirin.

Uygulamada, [ParagraphFormat.setMarginLeft] paragraf gövdesinin sol konumunu, [ParagraphFormat.setIndent] ise ilk satırın bu kenar boşluğuna göre konumunu tanımlar. Sarkıt girinti oluşturmak için `setMarginLeft`a pozitif bir değer, `setIndent`e negatif bir değer verin.

Bu biçimlendirme bibliyografiler, referanslar, sözlük girdileri ve satırların paragraf gövdesinin altında hizalanması gereken diğer paragraflar için yararlıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her paragraf için [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) değerine pozitif bir değer geçirin.
6. Sarkıt etkisini yaratmak için [ParagraphFormat.setIndent](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setindent/) değerine negatif bir değer geçirin.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilmiş sunumu kaydedin.

Bu kod bir paragraf için sarkıt girinti nasıl ayarlanır gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragrafların sarkıt girintisi](hanging_indent.png)

### **Paragraf Sonu Çalıştırma Özelliklerini Ayarlama**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) paragraf son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki örnek ikinci paragrafın son işaretine bir yazı tipi boyutu ve Latin yazı tipi atar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) oluşturun veya yükleyin ve bir slayta erişin.
2. Bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin ve varsayılan paragrafını temizleyin.
3. İki paragraf oluşturun ve onlara metin bölümleri ekleyin.
4. İkinci paragrafın son işareti için bir [PortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portionformat/) oluşturun.
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) ve [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) ayarlayın.
6. [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) ile formatı atayın ve sunumu kaydedin.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Render Edilen Satırları Sayma**

[Paragraph.getLinesCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/#getLinesCount) bir paragrafın metin yerleşimi sonrası kapladığı satır sayısını saymak için kullanılır; otomatik kaydırma da dahildir. Bu, sunum şablonlarında metin uzunluğunu ve yerleşimini kontrol ederken faydalıdır.

Bir paragraf, [TextFrame.getParagraphs](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/#getParagraphs) içinde bir öğedir ve birkaç render edilmiş satır kaplayabilir. Paragraf içinde açık bir satır sonu karakteri yeni bir satır oluşturur ancak yeni bir paragraf oluşturmaz. Otomatik kaydırma, mevcut genişliğe göre satır oluşturur ve metne açık satır sonu karakteri eklemez. Bu nedenle paragraf sayısını veya satır sonu karakterlerini saymak render edilen satır sayısını vermez.

Aşağıdaki örnek bir metin şekli oluşturur, satırlarını sayar, şekli daraltır ve ardından metni daha kısa bir dizeyle değiştirir. Kaydırma etkinleştirilmiş ve otomatik sığdırma devre dışı bırakılmıştır; böylece şekil genişliği, metni otomatik olarak küçültmeden veya şekli yeniden boyutlandırmadan kaydırmayı kontrol eder. Şekil boyutları puan cinsindendir. Son olarak, örnek bir paragraf daha ekler ve metin çerçevesi boyunca satır sayılarını toplar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Bu metin ve bu boyutlarla şekli daraltmak satır sayısını artırırken, kısa dizgeyle değiştirmek azaltır. Kesin sayılar yazı tipi bulunabilirliği ve ikamesi, yazı tipi boyutu, kenar boşlukları, girinti, kaydırma ve otomatik sığdırma ayarlarına göre değişebilir. Bir şablonu kontrol ederken hedef ortam için planlanan yazı tiplerini ve yerleşim ayarlarını kullanın.

Satır sayısı yalnız başına metnin kapsayıcısını aşıp aşmadığını belirlemez. Kullanılabilir yükseklik, satır yüksekliği, paragraf ve satır aralığı ve otomatik sığdırma davranışı da önemlidir; kaydırma devre dışı bırakıldığında tek bir satır bile mevcut genişliği aşabilir.

## **Paragraf İçeriğini İçe ve Dışa Aktarma**

### **HTML Metnini Paragraflara İçe Aktarma**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) kullanarak HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürün.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Bir slayta bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ekleyin.
3. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin ve varsayılan paragrafı temizleyin.
4. Kaynak HTML dizesini tanımlayın veya okuyun.
5. HTML dizesini [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) metoduna geçirin.
6. Değiştirilmiş sunumu kaydedin.

Bu JavaScript örneği HTML'i bir metin çerçevesine içe aktarır:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Paragraf Metnini HTML'ye Dışa Aktarma**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) kullanarak seçili paragraf aralığını HTML olarak dışa aktarın.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) oluşturun veya yükleyin.
2. Slayta erişin ve metni içeren [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/)'i bulun.
3. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesine erişin.
4. Başlangıç paragraf indeksi ve dışa aktarılacak paragraf sayısı ile [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) metodunu çağırın.
5. Dönen HTML dizesini bir dosyaya yazın.

Bu bağımsız JavaScript örneği bir metin şekli oluşturur ve tüm paragraflarını dışa aktarır:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Paragrafı Görüntü Olarak Render Etme**

[Paragraph.getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/#getImage) tek bir paragrafı doğrudan render eder ve bir [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) döndürür. Sonucu [IImage.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/#save) ile dosyaya kaydedin. İçeren şekli render etmenize veya bitmap'i manuel olarak kırpmanıza gerek yoktur.

[Paragraph.getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/#getImage), paragraf ebeveyn koleksiyonunda bulunamazsa, geçerli bir render sınırı yoksa veya render edilemezse `null` dönebilir. Sonucu kaydetmeden önce kontrol edin ve kullanımdan sonra dönen görüntüyü serbest bırakın.

#### **Varsayılan Ölçekte Paragrafı Render Etme**

Aşağıdaki metin kutusunda üç paragraf bulunur:

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek ikinci paragrafı normal bir metin şekli içinde varsayılan ölçekte render eder ve sonucu PNG formatında kaydeder. `finally` bloğu görüntünün doğru şekilde serbest bırakılmasını sağlar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Sonuç:

![Paragraf görüntüsü](paragraph_to_image_output.png)

#### **Tablo Hücresinde Ölçeklendirilmiş Paragraf Render Etme**

`scaleX` ve `scaleY` parametrelerini kabul eden [Paragraph.getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/#getImage) aşırı yüklemesini kullanarak yatay ve dikey ölçek faktörlerini ayarlayın. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin ve yüksekliğinin iki katı olarak render eder ve sonucu PNG görüntüsü olarak kaydeder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

`1` faktörü ekseni varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` genişliği ve yüksekliği yaklaşık iki katına çıkarır; bu da dört kat daha fazla piksel demektir. Daha büyük faktörler yakınlaştırma veya yüksek çözünürlüklü çıktı için daha keskin metin üretir, ancak bellek kullanımını ve dosya boyutunu artırır. `1`'in altındaki faktörler daha az detaylı, daha küçük görüntüler üretir. En-boy oranını korumak için eşit faktörler kullanın; farklı yatay ve dikey faktörler çıktıyı bağımsız olarak uzatır.

[Shape.getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getImage) ile tüm şekli render etmek, çıktının şeklin doldurmasını, kenarlığını veya diğer görsel bağlamını içermesi gerektiğinde kullanışlıdır. Yalnızca paragraf görüntüsü için [Paragraph.getImage] kullanılmalıdır.

## **SSS**

**Bir metin çerçevesinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. Kaydırmayı devre dışı bırakmak için [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/setwraptext/) özelliğini `false` olarak ayarlayın.

**Belirli bir paragrafın slayt üzerindeki kesin sınırlarını nasıl alabilirim?**

Paragrafın sınırlayıcı dikdörtgenini almak için [Paragraph.getRect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/getrect/) metodunu kullanın. Tek bir bölümün sınırlarını elde etmek için [Portion.getRect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/#getRect) metodunu kullanın.

**Paragraf hizalaması (sol, sağ, orta ya da iki yana yaslama) nerede kontrol edilir?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraphformat/setalignment/) paragraf seviyesinde bir ayardır ve bireysel bölüm biçimlendirmesinden bağımsız olarak bütün paragrafı etkiler.

**Paragrafın bir kısmı için düzeltme dili ayarlayabilir miyim?**

Evet. Bireysel bölümler için [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) ayarlayarak aynı paragrafta birden çok dilde metin bulunmasını sağlayabilirsiniz.