---
title: JavaScript Kullanarak Sunumlarda Madde İşaretli ve Numaralı Listeleri Yönetme
linktitle: Listeleri Yönet
type: docs
weight: 60
url: /tr/nodejs-java/manage-lists/
keywords:
- madde işareti
- madde işaretli liste
- numaralı liste
- sembol madde işareti
- resimli madde işareti
- özel madde işareti
- çok seviyeli liste
- madde işareti oluştur
- madde işareti ekle
- liste ekle
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint ve OpenDocument sunumlarında madde işaretli, resimli, çok seviyeli ve numaralı listelerin nasıl oluşturulacağını ve biçimlendirileceğini öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, PowerPoint ve OpenDocument sunumlarında madde işaretli ve numaralı listeler oluşturmanıza ve biçimlendirmenize olanak tanır. Bir liste öğesi, madde işareti ayarları paragraf biçimi aracılığıyla kontrol edilen bir paragraftır.

[Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) sınıfını, paragraf seviyesindeki liste ayarlarına erişmek için kullanın. Ana giriş noktası `Paragraph.getParagraphFormat().getBullet()`, bir [BulletFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bulletformat/) nesnesi döndürür. Bu nesne ile madde işareti türünü, sembolünü, resmini, rengini, boyutunu, numaralandırma stilini ve başlangıç numarasını ayarlayabilirsiniz.

Bu makale aşağıdakileri gösterir:

- özel bir sembolle madde işaretli bir liste oluşturma
- resimli madde işareti oluşturma
- paragraf derinliğini ayarlayarak çok seviyeli bir liste oluşturma
- numaralı bir liste oluşturma
- var olan bir sunumda liste biçimlendirmesini inceleme ve değiştirme

## **Madde İşaretli Liste Oluşturma**

Madde işaretli bir liste oluşturmak için, bir [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) nesnesine [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) nesneleri ekleyin ve `BulletFormat.setType` yöntemini [BulletType.Symbol](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bullettype/) olarak ayarlayın. Ardından, madde işareti görünümünü kontrol etmek için `BulletFormat.setChar`, `BulletFormat.getColor` ve `BulletFormat.setHeight` ayarlarını yapabilirsiniz.

Şu anda bir slaytta madde işaretli liste nasıl oluşturulacağını gösteren JavaScript kodu:

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Sembol madde işaretleri](symbol_bullets.png)

## **Numaralı Liste Oluşturma**

Öğelerin sırası önemli olduğunda numaralı listeler kullanın. `BulletFormat.setType` yöntemini [BulletType.Numbered](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bullettype/) olarak ayarlayın. Ayrıca, `BulletFormat.setNumberedBulletStyle` ile bir numaralandırma biçimi seçebilir veya listenin 1 yerine farklı bir değerden başlamasını istediğinizde `BulletFormat.setNumberedBulletStartWith` ayarını yapabilirsiniz.

Aşağıdaki JavaScript kodu, bir slaytta numaralı liste nasıl oluşturulacağını gösterir:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Numaralı madde işaretleri](numbered_bullets.png)

## **Resimli Madde İşareti Oluşturma**

Aspose.Slides, normal bir madde işareti sembolünü bir görselle değiştirmenize olanak tanır. Resimli madde işaretleri, küçük boyutlarda okunabilirliğini koruyan basit görsellerle, örneğin simgeler veya küçük şeffaf PNG dosyalarıyla en iyi şekilde çalışır.

{{% alert color="primary" %}}
İdeal olarak, normal madde işareti sembolünü bir görselle değiştirmeyi düşünüyorsanız, şeffaf bir arka plana sahip basit bir grafik seçmek en iyisidir. Bu tür görseller, özel madde işareti sembolleri olarak iyi çalışır.
{{% /alert %}}

Resimli madde işareti oluşturmak için, `Presentation.getImages().addImage` yöntemiyle bir görseli [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) nesnesine ekleyin ve dönen [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesnesini `BulletFormat.getPicture().setImage` metoduna atayın. Görseli atamadan önce `BulletFormat.setType` yöntemini [BulletType.Picture](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/bullettype/) olarak ayarlayın.

Diyelim ki elimizde "image.png" adlı bir dosya var:

![Madde işaretleri için bir resim](picture_for_bullets.png)

Aşağıdaki JavaScript kodu, bir slaytta resimli madde işaretleri nasıl oluşturulacağını gösterir:

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

Sonuç:

![Resimli madde işaretleri](picture_bullets.png)

## **Çok Seviyeli Liste Oluşturma**

`ParagraphFormat.setDepth` yöntemini kullanarak liste öğelerini farklı seviyelere yerleştirin. Seviye 0 en üst seviyedir, seviye 1 onun altında iç içe bir seviyedir ve bu şekilde devam eder.

Aşağıdaki JavaScript kodu, çok seviyeli bir madde işaretli liste nasıl oluşturulacağını gösterir:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Çok seviyeli liste](multilevel_list.png)

## **Var Olan Bir Listeyi Değiştirme**

Var olan bir sunumda liste biçimlendirmesini değiştirmek için, hedef paragrafı erişin ve `ParagraphFormat.getBullet` ayarlarını güncelleyin. Listeler oluşturmak için kullanılan aynı özellikler, PPT, PPTX veya ODP dosyasından yüklenen listeleri incelemek veya değiştirmek için de kullanılabilir.

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Madde işaretli ve numaralı listeler PDF veya görüntülere aktarılabilir mi?**

Evet. Hedef format ilgili metin düzenini ve madde işareti özelliklerini desteklediğinde, Aspose.Slides liste biçimlendirmesini korur.

**Var olan sunumlardaki listeleri düzenleyebilir miyim?**

Evet. Sunumu yükleyin, hedef paragrafı erişin, `ParagraphFormat.getBullet` ayarlarını inceleyin veya güncelleyin ve ardından sunumu kaydedin.

**Listeler Latin olmayan metin içerebilir mi?**

Evet. Liste öğesi metni Unicode karakterler içerebilir, bu sayede çok dilli sunumlarda listeler oluşturabilirsiniz. Sunumda kullanılan yazı tiplerinin ihtiyacınız olan karakterleri desteklediğinden emin olun.