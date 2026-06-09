---
title: JavaScript'te Sunumlardan Şekil Etkin Özelliklerini Alın
linktitle: Etkin Özellikler
type: docs
weight: 50
url: /tr/nodejs-java/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık rig'i
- köşe şekli
- metin çerçevesi
- metin stili
- font yüksekliği
- doldurma biçimi
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'in Java aracılığıyla şekil etkin özelliklerini nasıl hesapladığını ve kesin PowerPoint render'ı için uyguladığını keşfedin."
---
## **Genel Bakış**

Bu konu **yerel** ve **etkin** özellikler arasındaki farkı açıklar. Yerel değerler, belirli bir biçimlendirme seviyesinde doğrudan ayarlanan değerlerdir, örneğin:

1. Bir slayttaki bölüm (portion) özellikleri.
1. Bir düzen ya da ana slaytta prototip şekil metin stilleri, bölümün metin çerçevesi şekli bir taneye sahipse.
1. Sunumdaki genel metin ayarları.

Yerel değerler herhangi bir seviyede tanımlanabilir veya atlanabilir. Aspose.Slides son “görüntülendiği gibi” biçimlendirmeye ihtiyaç duyduğunda, kalıtım zincirini çözer ve **etkin** değerleri döndürür. Bu değerlere yerel biçim nesnesi üzerinde `getEffective` metodunu çağırarak ulaşabilirsiniz.

Aşağıdaki örnek, etkin değerlerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir metin çerçevesi ve en az bir bölüm içeren bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) olduğunu varsayar.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Etkin biçimlendirme verileri, kalıtım uygulandıktan sonra mevcut hesaplanmış biçimlendirmeyi temsil eder. Mevcut uygulamada, bazı etkin veri nesneleri dahili olarak önbelleğe alınabilir. Üst veya kalıtılan biçimlendirme değiştirildikten sonra `getEffective` metodunu tekrar çağırmak, önbellekteki verileri yenileyebilir ve daha önce alınan nesne artık önceki durumu temsil etmeyebilir. Etkin değerleri sonraki kullanım için saklamanız gerekiyorsa, font yüksekliği, doldurma rengi, font stili veya hizalama gibi gerekli özellikleri kendi veri nesnenize kopyalayın.
{{% /alert %}}

## **Kamera için Etkin Özellikleri Alın**

Aspose.Slides, bir kameranın etkin özelliklerini almanıza olanak tanır. Etkin kamera veri nesnesi değiştirilemez kamera özelliklerini içerir ve [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) için döndürülen etkin değerler aracılığıyla ortaya çıkar.

İlk slayttaki ilk şeklin 3D biçimlendirmesi olduğunu varsayarak, aşağıdaki kod örneği kameranın etkin özelliklerini nasıl alacağınızı gösterir.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Işık Rig'i için Etkin Özellikleri Alın**

Aspose.Slides, bir ışık rig'inin etkin özelliklerini almanıza izin verir. Etkin ışık rig veri nesnesi değiştirilemez ışık rig özelliklerini içerir ve [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) için döndürülen etkin değerler aracılığıyla ortaya çıkar.

İlk slayttaki ilk şeklin 3D biçimlendirmesi olduğunu varsayarak, aşağıdaki kod örneği ışık rig'inin etkin özelliklerini nasıl alacağınızı gösterir.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Köşe Şekli (Bevel) için Etkin Özellikleri Alın**

Aspose.Slides, bir şekil köşesinin (bevel) etkin özelliklerini almanıza imkan tanır. Etkin şekil köşe veri nesnesi, bir şeklin değiştirilemez yüzey-relief özelliklerini içerir ve [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) için döndürülen etkin değerler aracılığıyla ortaya çıkar.

İlk slayttaki ilk şeklin 3D biçimlendirmesi olduğunu varsayarak, aşağıdaki kod örneği bir şeklin üst köşesinin etkin özelliklerini nasıl alacağınızı gösterir.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Metin Çerçevesi için Etkin Özellikleri Alın**

Aspose.Slides kullanarak, bir metin çerçevesinin etkin özelliklerini alabilirsiniz. Döndürülen etkin veri nesnesi metin çerçevesi biçimlendirme özelliklerini içerir.

İlk slayttaki ilk şeklin bir metin çerçevesi içeren bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) olduğunu varsayarak, aşağıdaki kod örneği etkin metin çerçevesi biçimlendirme özelliklerini nasıl alacağınızı gösterir.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Metin Stili için Etkin Özellikleri Alın**

Aspose.Slides kullanarak, bir metin stilinin etkin özelliklerini alabilirsiniz. Döndürülen etkin veri nesnesi metin stili özelliklerini içerir.

İlk slayttaki ilk şeklin bir metin çerçevesi içeren bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) olduğunu varsayarak, aşağıdaki kod örneği etkin metin stili özelliklerini nasıl alacağınızı gösterir.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Etkin Font Yüksekliği Değerini Alın**

Aspose.Slides kullanarak etkin font yüksekliğini alabilirsiniz. Aşağıdaki kod, bir bölümüün (portion) etkin font yüksekliğinin, farklı sunum yapısı seviyelerinde yerel font yüksekliği değerleri ayarlandıktan sonra nasıl değiştiğini gösterir.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Tablo için Etkin Doldurma Biçimini Alın**

Aspose.Slides kullanarak, farklı tablo bölümleri için etkin doldurma biçimlendirmesini alabilirsiniz. Döndürülen etkin veri nesnesi doldurma biçimlendirme özelliklerini içerir. Hücre biçimlendirmesi satır biçimlendirmesinden, satır biçimlendirmesi sütun biçimlendirmesinden ve sütun biçimlendirmesi tüm tablo biçimlendirmesinden daha yüksek önceliğe sahiptir.

Sonuç olarak, etkin hücre biçimlendirme özellikleri tablo hücresini çizmeye kullanılır. İlk slayttaki ilk şeklin bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/table/) olduğunu varsayarak, aşağıdaki kod örneği farklı tablo bölümleri için etkin doldurma biçimlendirmesini nasıl alacağınızı gösterir.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **SSS**

**`getEffective` bir anlık görüntü (snapshot) döndürür mü?**

Her zaman değil. Etkin veri, kalıtım uygulandıktan sonra hesaplanmış biçimlendirmeyi temsil eder, ancak bazı etkin veri nesneleri dahili olarak önbelleğe alınabilir. Sonraki bir `getEffective` çağrısı biçimlendirmeyi yeniden hesaplayabilir ve önbellekteki verileri yenileyebilir; bu nedenle daha önce alınan nesne dayanıklı bir anlık görüntü olarak ele alınmamalıdır.

**Etkin özellikleri ne zaman tekrar okumalıyım?**

Yerel biçimlendirme, üst stiller, düzen biçimlendirmesi, ana biçimlendirme veya sunum düzeyindeki varsayılanlar değiştirildikten sonra `getEffective` metodunu tekrar çağırın. Bir sonraki çağrı biçimlendirme hiyerarşisini yeniden değerlendirir ve geçerli etkin sonucu döndürür.

**Bir düzen/ana slayt değiştirildiğinde veya kaldırıldığında, zaten alınmış etkin özellikler etkilenir mi?**

Evet, ancak değişiklik bir sonraki `getEffective` çağrısında yansıtılır. Bir üst biçimlendirme kaynağı değiştirildiğinde veya kaldırıldığında, daha önce alınan etkin veri eski (stale) olabilir. `getEffective` tekrar çağrıldığında, Aspose.Slides biçimlendirme ağacını yeniden değerlendirir ve ortaya çıkan fontlar, renkler, boyutlar veya diğer değerler değişebilir.

**Etkin veri nesneleri üzerinden değerleri değiştirebilir miyim?**

Hayır. Etkin veri nesneleri hesaplanmış değerleri sunar. Değişiklikleri yerel biçimlendirme nesnelerinde yapın ve ardından etkin değerleri tekrar alın.

**Bir özellik şekil seviyesinde, düzen/ana slaytta ve genel ayarlarda hiç ayarlanmamışsa ne olur?**

Etkin değer, PowerPoint ve Aspose.Slides varsayılanlarını içeren varsayılan mekanizma tarafından belirlenir. Çözülmüş bu değer mevcut etkin verinin bir parçası haline gelir.

**Etkin bir font değerinden, boyutun veya tipin hangi seviyeden geldiğini anlayabilir miyim?**

Doğrudan değil. Etkin veri son değeri döndürür. Kaynağı bulmak için bölümler, paragraflar, metin çerçevesi ve düzen, ana ve sunum seviyelerindeki metin stillerindeki yerel değerleri kontrol edin; ilk açık tanımın nerede göründüğünü görebilirsiniz.

**Neden etkin değerler bazen yerel değerlerle aynı görünüyor?**

Çünkü yerel değer, nihai değer olmuş (daha yüksek seviyeden bir kalıtım gerekmemiş) ve bu durumda etkin değer yerel değerle aynı olur.

**Etkin özellikleri ne zaman kullanmalı, yerel olanlarla ne zaman çalışmalıyım?**

Tüm kalıtım uygulandıktan sonra “görüntülendiği gibi” sonucu elde etmeniz gerektiğinde etkin veriyi kullanın; örneğin renkleri, girintileri veya boyutları hizalamak gibi. Bu değerleri daha sonra format değişikliklerinden bağımsız tutmanız gerekiyorsa, gerekli özellikleri kendi nesnenize kopyalayın. Belirli bir seviyede formatı değiştirmek istiyorsanız, yerel özellikleri değiştirin ve gerekirse sonucu doğrulamak için tekrar etkin veriyi okuyun.