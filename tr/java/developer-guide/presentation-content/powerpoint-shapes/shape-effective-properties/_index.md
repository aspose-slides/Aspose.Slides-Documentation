---
title: Java'da Sunumlardan Şekil Etkin Özelliklerini Al
linktitle: Etkin Özellikler
type: docs
weight: 50
url: /tr/java/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık sistemi
- kiriş şekli
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'nın şekil etkin özelliklerini nasıl hesapladığını ve kesin PowerPoint renderlaması için nasıl uyguladığını keşfedin."
---
## **Genel Bakış**

Bu konu **yerel** ve **etkin** özellikler arasındaki farkı açıklar. Yerel değerler, belirli bir biçimlendirme seviyesinde doğrudan ayarlanan değerlerdir; örneğin:

1. Bir slayttaki bölüm (portion) özellikleri.
1. Bir düzen ya da ana slayttaki prototip şekil metin stilleri, bölümün metin çerçevesi şekline bir tane varsa.
1. Sunumdaki küresel metin ayarları.

Yerel değerler herhangi bir seviyede tanımlanabilir veya atlanabilir. Aspose.Slides, nihai “görüntülendiği gibi” biçimlendirmeye ihtiyaç duyduğunda kalıtım zincirini çözer ve **etkin** (effective) değerleri döndürür. Bu değerlere, yerel format nesnesinde `getEffective` yöntemini çağırarak ulaşabilirsiniz.

Aşağıdaki örnek, etkin değerlerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) olduğunu ve bir metin çerçevesi ile en az bir bölüm (portion) içerdiğini varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

Etkin biçimlendirme verileri, kalıtım uygulandıktan sonra hesaplanan geçerli biçimlendirmeyi temsil eder. Mevcut uygulamada, [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPortionFormatEffectiveData) gibi bazı etkin veri nesneleri dahili olarak önbelleğe alınabilir. Üst ya da kalıtılan biçimlendirme değiştirildikten sonra `getEffective` yeniden çağrıldığında önbellek yenilenir ve daha önce elde edilen nesne artık önceki durumu temsil etmeyebilir. Etkin değerleri daha sonraki kullanım için korumanız gerekiyorsa, yazı tipi yüksekliği, dolgu rengi, yazı tipi stili veya hizalama gibi gerekli özellikleri kendi veri nesnenize kopyalayın.

{{% /alert %}}

## **Kamera'nın Etkin Özelliklerini Al**

Aspose.Slides, bir kameranın etkin özelliklerini almanıza olanak tanır. [ICameraEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICameraEffectiveData) arabirimi, etkin kamera özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ICameraEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICameraEffectiveData) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IThreeDFormatEffectiveData) aracılığıyla sunulur ve [IThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IThreeDFormat) için etkin değerleri sağlar.

Aşağıdaki kod örneği, kamera için etkin özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3B (3D) biçimlendirmeye sahip olduğunu varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Işık Sisteminin Etkin Özelliklerini Al**

Aspose.Slides, bir ışık sisteminin (light rig) etkin özelliklerini almanıza olanak tanır. [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ILightRigEffectiveData) arabirimi, etkin ışık sistemi özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ILightRigEffectiveData) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IThreeDFormatEffectiveData) aracılığıyla sunulur ve [IThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IThreeDFormat) için etkin değerleri sağlar.

Aşağıdaki kod örneği, ışık sistemi için etkin özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3B (3D) biçimlendirmeye sahip olduğunu varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Şekil Kirişinin Etkin Özelliklerini Al**

Aspose.Slides, bir şekil kıvrımının (bevel) etkin özelliklerini almanıza olanak tanır. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeBevelEffectiveData) arabirimi, bir şekil için etkin yüzey (face‑relief) özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeBevelEffectiveData) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IThreeDFormatEffectiveData) aracılığıyla sunulur ve [IThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IThreeDFormat) için etkin değerleri sağlar.

Aşağıdaki kod örneği, bir şeklin üst kıvrımı için etkin özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3B (3D) biçimlendirmeye sahip olduğunu varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Metin Çerçevesinin Etkin Özelliklerini Al**

Aspose.Slides kullanarak bir metin çerçevesinin etkin özelliklerini alabilirsiniz. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextFrameFormatEffectiveData) arabirimi, etkin metin çerçevesi biçimlendirme özelliklerini içerir.

Aşağıdaki kod örneği, etkin metin çerçevesi biçimlendirme özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Metin Stiline Etkin Özellikleri Al**

Aspose.Slides kullanarak bir metin stilinin etkin özelliklerini alabilirsiniz. [ITextStyleEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextStyleEffectiveData) arabirimi, etkin metin stili özelliklerini içerir.

Aşağıdaki kod örneği, etkin metin stili özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Etkin Yazı Tipi Yüksekliği Değerini Al**

Aspose.Slides kullanarak etkin yazı tipi yüksekliğini alabilirsiniz. Aşağıdaki kod, bir bölümün (portion) etkin yazı tipi yüksekliğinin, farklı sunum yapısı seviyelerinde yerel yazı tipi yüksekliği değerleri ayarlandığında nasıl değiştiğini gösterir.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tablo İçin Etkin Dolgu Biçimini Al**

Aspose.Slides kullanarak farklı tablo bölümleri için etkin dolgu biçimlendirmesini alabilirsiniz. [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IFillFormatEffectiveData) arabirimi, etkin dolgu biçimlendirme özelliklerini içerir. Hücre biçimlendirmesi, satır biçimlendirmesinden, satır biçimlendirmesi sütun biçimlendirmesinden ve sütun biçimlendirmesi bütün tablo biçimlendirmesinden daha yüksek önceliğe sahiptir.

Sonuç olarak, tablo hücresini çizerken [ICellFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICellFormatEffectiveData) özellikleri kullanılır. Aşağıdaki kod örneği, farklı tablo bölümleri için etkin dolgu biçimlendirmesinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) olduğunu varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **SSS**

**`getEffective` bir anlık görüntü (snapshot) döndürür mü?**

Her zaman değildir. Etkin veri, kalıtım uygulandıktan sonra hesaplanan biçimlendirmeyi temsil eder, ancak bazı etkin veri nesneleri dahili olarak önbelleğe alınabilir. Sonraki bir `getEffective` çağrısı biçimlendirmeyi yeniden hesaplayabilir ve önbellek verisini yenileyebilir; bu nedenle daha önce elde edilen nesne kalıcı bir anlık görüntü olarak kabul edilmemelidir.

**Etkin özellikleri ne zaman tekrar okumalıyım?**

Yerel biçimlendirme, üst stiller, düzen biçimlendirmesi, ana (master) biçimlendirme veya sunum düzeyindeki varsayılanlar değiştirildikten sonra `getEffective` yeniden çağrılmalıdır. Sonraki çağrı, biçimlendirme hiyerarşisini yeniden değerlendirir ve geçerli etkin sonucu döndürür.

**Bir düzen/ana slayt değiştirildiğinde veya kaldırıldığında, zaten alınmış etkin özellikler etkilenir mi?**

Evet, ancak değişiklik bir sonraki `getEffective` çağrısında yansır. Üst bir biçimlendirme kaynağı değiştirildiğinde veya kaldırıldığında, daha önce elde edilen etkin veri eski olabilir. `getEffective` tekrar çağrıldığında Aspose.Slides biçimlendirme ağacını yeniden değerlendirir ve ortaya çıkan yazı tipleri, renkler, boyutlar veya diğer değerler değişebilir.

**Etkin veri nesneleri üzerinden değerleri değiştirebilir miyim?**

Hayır. Etkin veri nesneleri sadece hesaplanmış değerleri sağlar. Değişiklikleri yerel biçimlendirme nesnelerinde yapın ve ardından etkin değerleri tekrar alın.

**Bir özellik şekil seviyesinde, düzen/ana slaytta ve küresel ayarlarda hiç ayarlanmamışsa ne olur?**

Etkin değer, PowerPoint ve Aspose.Slides varsayılanlarını içeren varsayılan mekanizma tarafından belirlenir. Çözülen bu değer, geçerli etkin verinin bir parçası haline gelir.

**Etkin bir yazı tipi değerinden, boyutu veya yazı tipini hangi seviyenin sağladığını anlayabilir miyim?**

Doğrudan değil. Etkin veri nihai değeri döndürür. Kaynağı bulmak için bölüm, paragraf, metin çerçevesi ve düzen, ana ve sunum seviyelerindeki metin stillerindeki yerel değerleri kontrol ederek ilk açık tanımın nerede yapıldığını inceleyin.

**Neden etkin değerler bazen yerel değerlerle aynı görünür?**

Yerel değer son olarak kalır (daha üst seviyeden bir kalıtım gerekmez) ve bu yüzden etkin değer yerel değerle aynı olur.

**Etkin özellikleri ne zaman, yerel özellikleri ne zaman kullanmalıyım?**

Tüm kalıtım uygulandıktan sonra “görüntülendiği gibi” sonucu elde etmeniz gerektiğinde etkin verileri kullanın; örneğin renkleri, girintileri veya boyutları hizalamak gibi. Bu değerleri daha sonraki biçimlendirme değişikliklerinden bağımsız olarak korumanız gerekiyorsa, gerekli özellikleri kendi nesnenize kopyalayın. Belirli bir seviyede biçimlendirme değiştirmeniz gerektiğinde, yerel özellikleri değiştirin ve gerekirse sonucu doğrulamak için tekrar etkin verileri okuyun.