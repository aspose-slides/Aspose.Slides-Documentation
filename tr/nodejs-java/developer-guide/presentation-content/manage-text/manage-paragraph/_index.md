---
title: JavaScript ile PowerPoint Metin Paragraflarını Yönetme
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
- paragrafı yönet
- madde işaretini yönet
- paragraf girintisi
- asılı girinti
- paragraf madde işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metni HTML'ye
- paragrafı HTML'ye
- paragrafı görüntüye
- metni görüntüye
- paragrafı dışa aktar
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile paragraflar, bölümler, madde işaretleri, numaralı listeler, girintiler, HTML içeriği ve paragraf görüntüleri oluşturmayı ve biçimlendirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, metni bir metin çerçeveleri, paragraflar ve bölümler hiyerarşisi olarak temsil eder:

* [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) bir şeklin içindeki metin kapsayıcısını temsil eder ve paragraf koleksiyonuna erişim sağlar.
* [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) bir metin çerçevesindeki tek bir paragrafı temsil eder ve bölümlerine ve paragraf düzeyinde biçimlendirmeye erişim sağlar.
* [Portion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/portion/) bir paragraftaki metin çalışmasını temsil eder. Her bölüm kendi metnine ve karakter düzeyinde biçimlendirmeye sahip olabilir.

Bu nedenle bir paragraf, birden çok bölüm kullanarak farklı yazı tipleri, renkler, boyutlar ve diğer biçimlendirmeler içeren metin barındırabilir.

## **Paragrafları Oluşturma ve Biçimlendirme**

### **Birden Çok Bölüm ile Paragraflar Oluşturma**

İşte verilen adımlar, her biri üç bölüm içeren üç paragrafla bir metin çerçevesi oluşturur:

1. Bir [Presentation] sınıfının örneğini oluşturun.  
2. İlgili slayta indeksini kullanarak erişin.  
3. Slayta dikdörtgen bir [AutoShape] ekleyin.  
4. Şeklin [TextFrame] özelliğine erişin.  
5. Varsayılan paragrafı kullanın ve metin çerçevesine iki ek [Paragraph] nesnesi ekleyin.  
6. Her paragrafın üç bölüm içermesi için yeterli sayıda [Portion] nesnesi ekleyin. Varsayılan paragraf zaten bir boş bölüm içerir.  
7. Her bölümün metnini ayarlayın.  
8. [Portion.getPortionFormat] aracılığıyla karakter düzeyinde biçimlendirme uygulayın.  
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

## **Madde İşaretli ve Numaralı Listeler Oluşturma**

### **Madde İşaretli veya Numaralı Liste Oluşturma**

Madde işaretleri ve numaralar, ilgili öğelerin daha kolay taranmasını sağlar. Aspose.Slides'te liste ayarları [BulletFormat] aracılığıyla tanımlanır.

1. Bir [Presentation] sınıfının örneğini oluşturun.  
2. İlgili slayta indeksini kullanarak erişin.  
3. Seçilen slayta bir [AutoShape] ekleyin.  
4. Şeklin [TextFrame] özelliğine erişin.  
5. Metin çerçevesindeki varsayılan paragrafı kaldırın.  
6. Sembol madde işareti için bir [Paragraph] oluşturun.  
7. [BulletFormat.setType] değerini [BulletType.Symbol] olarak ayarlayın ve madde işareti karakterini belirtin.  
8. Paragraf metnini, girintiyi, madde işareti rengini ve yüksekliğini ayarlayın.  
9. Paragrafı metin çerçevesine ekleyin.  
10. İkinci bir paragraf oluşturun ve [BulletFormat.setType] değerini [BulletType.Numbered] olarak ayarlayın.  
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

Resim madde işaretleri, sembol veya sayı yerine özel bir görüntü kullanmanıza olanak tanır.

1. Bir [Presentation] sınıfının örneğini oluşturun.  
2. İlgili slayta indeksini kullanarak erişin.  
3. Bir [AutoShape] ekleyin ve onun [TextFrame] özelliğine erişin.  
4. Metin çerçevesindeki varsayılan paragrafı kaldırın.  
5. Madde işareti görüntüsünü yükleyin ve sunumun görüntü koleksiyonuna [PPImage] olarak ekleyin.  
6. Bir [Paragraph] oluşturun ve metnini ayarlayın.  
7. [BulletFormat.setType] değerini [BulletType.Picture] olarak ayarlayın.  
8. [BulletFormat.getPicture] aracılığıyla görüntüyü atayın ve madde işareti yüksekliğini ayarlayın.  
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

### **Çok Katmanlı Liste Oluşturma**

[ParagraphFormat.setDepth] ayarını, paragrafları bir listenin farklı seviyelerine yerleştirmek için kullanın. Üst seviye derinliği `0` dır.

1. Bir [Presentation] oluşturun ve bir slayta erişin.  
2. Bir [AutoShape] ekleyin ve metin çerçevesindeki varsayılan paragrafı temizleyin.  
3. Dört paragraf oluşturun ve madde işareti simgelerini yapılandırın.  
4. Bu paragrafların [ParagraphFormat.setDepth] değerlerini sırasıyla `0`, `1`, `2` ve `3` olarak ayarlayın.  
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu JavaScript örneği dört seviyeli bir madde işareti listesi oluşturur:

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

Numaralı bir paragrafta görüntülenecek başlangıç numarasını ayarlamak için [BulletFormat.setNumberedBulletStartWith] kullanın.

1. Bir [Presentation] oluşturun ve bir slayta [AutoShape] ekleyin.  
2. Şeklin metin çerçevesindeki varsayılan paragrafı temizleyin.  
3. Üç numaralı paragraf oluşturun.  
4. İlgili paragraflar için [BulletFormat.setNumberedBulletStartWith] değerini sırasıyla `2`, `3` ve `7` olarak ayarlayın.  
5. Paragrafları metin çerçevesine ekleyin ve sunumu kaydedin.

Bu JavaScript örneği her paragrafa özel bir başlangıç numarası atar:

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

[ParagraphFormat.setIndent] kullanarak bir paragrafın ilk satır girintisini kontrol edin. Bu yöntem, yalnızca ilk satırı paragrafın sol kenar boşluğuna göre hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

Paragrafın tamamını taşımak istediğinizde [ParagraphFormat.setMarginLeft] kullanın. Yalnızca ilk satırı taşımak istediğinizde [ParagraphFormat.setIndent] kullanın.

Aşağıdaki örnek birden çok paragraf oluşturur ve farklı [ParagraphFormat.setIndent] değerleri uygulayarak ilk satır girintisinin paragraf düzenini nasıl etkilediğini gösterir.

1. Bir [Presentation] sınıfının örneğini oluşturun.  
2. Hedef slayta erişin.  
3. Slayta dikdörtgen bir [AutoShape] ekleyin.  
4. Şeklin [TextFrame] özelliğine erişin ve varsayılan paragrafı kaldırın.  
5. Birkaç paragraf oluşturun ve bunlar için farklı [ParagraphFormat.setIndent] değerleri ayarlayın.  
6. Paragrafları metin çerçevesine ekleyin.  
7. Değiştirilmiş sunumu kaydedin.

Bu kod, bir paragraf girintisinin nasıl ayarlanacağını gösterir:

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

### **Asılı Girinti Ayarlama**

Asılı girinti, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides'te bu etkiyi [ParagraphFormat.setIndent] ile oluşturursunuz. İlk satırı paragraf gövdesine göre sola kaydırmak için negatif bir değer verin.

Pratikte, [ParagraphFormat.setMarginLeft] paragraf gövdesinin sol konumunu tanımlar ve [ParagraphFormat.setIndent] ilk satırın bu kenar boşluğuna göre konumunu belirler. Asılı girinti oluşturmak için `setMarginLeft` için pozitif bir değer ve `setIndent` için negatif bir değer geçirin.

Bu biçimlendirme, kaydırılmış satırların paragraf gövdesinin altında, ilk satırın ilk karakterinin altında değil, hizalanması gereken bibliyografyalar, referanslar, sözlük girdileri ve benzeri paragraflar için faydalıdır.

1. Bir [Presentation] sınıfının örneğini oluşturun.  
2. Hedef slayta erişin.  
3. Slayta dikdörtgen bir [AutoShape] ekleyin.  
4. Şeklin [TextFrame] özelliğine erişin ve varsayılan paragrafı kaldırın.  
5. Paragraflar oluşturun ve her paragraf için [ParagraphFormat.setMarginLeft] değerine pozitif bir değer verin.  
6. Asılı girinti etkisini oluşturmak için [ParagraphFormat.setIndent] değerine negatif bir değer verin.  
7. Paragrafları metin çerçevesine ekleyin.  
8. Değiştirilmiş sunumu kaydedin.

Bu kod, bir paragraf için asılı girintinin nasıl ayarlanacağını gösterir:

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

![Paragrafların asılı girintisi](hanging_indent.png)

### **Paragraf Son Çalıştırma Özelliklerini Ayarlama**

[Paragraph.setEndParagraphPortionFormat], paragraf son işaretinin biçimlendirmesini kontrol eder. Aşağıdaki örnek ikinci paragrafın son işaretine bir yazı tipi boyutu ve Latin yazı tipini atar:

1. Bir [Presentation] oluşturun veya yükleyin ve bir slayta erişin.  
2. Bir [AutoShape] ekleyin ve varsayılan paragrafını temizleyin.  
3. İki paragraf oluşturun ve onlara metin bölümleri ekleyin.  
4. İkinci paragrafın son işareti için bir [PortionFormat] oluşturun.  
5. [BasePortionFormat.setFontHeight] ve [BasePortionFormat.setLatinFont] ayarlarını yapın.  
6. [Paragraph.setEndParagraphPortionFormat] ile biçimi atayın ve sunumu kaydedin.

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

## **Paragraf İçeriğini İçe/Dışa Aktarma**

### **HTML Metnini Paragraflara İçe Aktarma**

[ParagraphCollection.addFromHtml] kullanarak HTML işaretlemesini bir metin çerçevesindeki paragraflara ve bölümlere dönüştürün.

1. Bir [Presentation] sınıfının örneğini oluşturun.  
2. Bir slayta erişin ve bir [AutoShape] ekleyin.  
3. Şeklin [TextFrame] özelliğine erişin ve varsayılan paragrafı kaldırın.  
4. Kaynak HTML dizesini tanımlayın veya okuyun.  
5. HTML dizesini [ParagraphCollection.addFromHtml] metoduna aktarın.  
6. Değiştirilmiş sunumu kaydedin.

Bu JavaScript örneği HTML'yi bir metin çerçevesine aktarır:

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

[ParagraphCollection.exportToHtml] kullanarak seçili paragraf aralığını HTML olarak dışa aktarın.

1. Bir [Presentation] örneği oluşturun veya yükleyin.  
2. Slayta erişin ve metni içeren [AutoShape] öğesini bulun.  
3. Şeklin [TextFrame] özelliğine erişin.  
4. Başlangıç paragraf indeksi ve dışa aktarılacak paragraf sayısını belirterek [ParagraphCollection.exportToHtml] metodunu çağırın.  
5. Döndürülen HTML dizesini bir dosyaya yazın.

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

### **Paragrafı Görüntü Olarak İşleme**

[Paragraph.getImage], bireysel bir paragrafı doğrudan işler ve bir [IImage] döndürür. Sonucu bir dosyaya [IImage.save] ile kaydedin. İçeren şekli işlemeye ya da bitmap'i manuel olarak kırpmaya gerek yoktur.

[Paragraph.getImage], paragraf ebeveyn koleksiyonunda bulunamazsa, geçerli bir renderleme sınırı yoksa ya da işlenemezse `null` döndürebilir. Kaydetmeden önce sonucu kontrol edin ve kullandıktan sonra döndürülen görüntüyü serbest bırakın.

#### **Paragrafı Varsayılan Ölçekte İşleme**

Aşağıdaki metin kutusu üç paragraf içerir:

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

Aşağıdaki örnek, normal bir metin şeklinin ikinci paragrafını varsayılan ölçekte işler ve döndürülen görüntüyü PNG formatında kaydeder. `finally` bloğu, görüntünün doğru şekilde serbest bırakılmasını sağlar.

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

#### **Paragrafı Tablo Hücresinde Ölçeklendirme ile İşleme**

`scaleX` ve `scaleY` parametrelerini kabul eden [Paragraph.getImage] aşırı yüklemesini kullanarak yatay ve dikey ölçek faktörlerini ayarlayın. Aşağıdaki örnek bir tablo oluşturur, paragrafı ilk hücresinde varsayılan genişliğinin ve yüksekliğinin iki katı ölçekle işler ve sonucu PNG görüntüsü olarak kaydeder.

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

`1` ölçek faktörü, ekseni varsayılan piksel boyutunda tutar. Örneğin, her iki faktör için `2` kullanmak, genişliği ve yüksekliği yaklaşık olarak varsayılan boyutların iki katı olan bir görüntü üretir ve bu da piksel sayısını dört katına çıkarır. Daha büyük faktörler, yakınlaştırma veya yüksek çözünürlüklü çıktı için genellikle daha keskin metin üretir, ancak bellek kullanımını ve dosya boyutunu artırır. `1`'in altındaki faktörler daha az detaylı, daha küçük görüntüler üretir. Paragrafın en‑boy oranını korumak için eşit faktörler kullanın; farklı yatay ve dikey faktörler çıktıyı bağımsız olarak uzatır.

[Shape.getImage] ile bütün bir şekli işlemek, çıktının şeklin doldurulmasını, kenarlığını veya diğer görsel bağlamını içermesi gerektiğinde hâlâ faydalıdır. Yalnızca paragraf görüntüsü için [Paragraph.getImage] kullanın.

## **SSS**

**Can I completely disable line wrapping inside a text frame?**

Evet. Satırların metin çerçevesinin kenarlarında kırılmasını engellemek için [TextFrameFormat.setWrapText] ayarını devre dışı bırakın.

**How can I get the exact on-slide bounds of a specific paragraph?**

Belirli bir paragrafın slayt üzerindeki tam sınırlarını elde etmek için [Paragraph.getRect] metodunu kullanın. Tek bir bölümün sınırlarını almak için [Portion.getRect] kullanılabilir.

**Where is paragraph alignment (left, right, center, or justify) controlled?**

[ParagraphFormat.setAlignment] bir paragraf‑düzeyi ayardır ve bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafa uygulanır.

**Can I set the proofing language for part of a paragraph?**

Evet. Bireysel bölümler için [BasePortionFormat.setLanguageId] ayarını yaparak bir paragrafta birden çok dilde metin bulunmasını sağlayabilirsiniz.