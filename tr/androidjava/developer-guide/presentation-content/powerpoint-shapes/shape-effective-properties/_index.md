---
title: Android'de Sunumlardan Şekil Effective Özelliklerini Al
linktitle: Effective Özellikleri
type: docs
weight: 50
url: /tr/androidjava/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık kiti
- bevel şekli
- metin çerçevesi
- metin stili
- yazı yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'in Java aracılığıyla etkili şekil özelliklerini nasıl hesapladığını ve uyguladığını keşfedin; böylece PowerPoint sunumları hassas bir şekilde işlenir."
---
## **Genel Bakış**

Bu konu **local** ve **effective** özellikleri arasındaki farkı açıklar. Local değerler, belirli bir biçimlendirme düzeyinde doğrudan ayarlanan değerlerdir, örneğin:

1. Bir slayttaki bölüm özellikleri.  
1. Bir düzen veya ana slaytta, bölümün metin çerçevesi şekline sahip olduğunda prototip şekil metin stilleri.  
1. Sunumdaki küresel metin ayarları.

Local değerler herhangi bir düzeyde tanımlanabilir veya atlanabilir. Aspose.Slides, nihai "render edilmiş" biçimlendirmeye ihtiyaç duyduğunda, kalıtım zincirini çözer ve **effective** değerleri döndürür. Bu değerlere yerel format nesnesi üzerindeki `getEffective()` metodunu çağırarak ulaşabilirsiniz.

Aşağıdaki örnek, effective değerlerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir metin çerçevesi ve en az bir bölüm içeren bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) olduğunu varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Effective biçimlendirme verileri, kalıtım uygulandıktan sonra mevcut hesaplanmış biçimlendirmeyi temsil eder. Mevcut uygulamada, [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportionformateffectivedata/) gibi bazı effective veri nesneleri dahili olarak önbelleğe alınabilir. Üst ya da kalıtılan biçimlendirme değiştirildikten sonra `getEffective()` metodunu tekrar çağırmak, önbellekteki verileri yenileyebilir ve daha önce elde edilen nesne artık önceki durumu yansıtmayabilir. Effective değerleri daha sonra tekrar kullanmak istiyorsanız, gerekli özellikleri (örneğin yazı yüksekliği, dolgu rengi, yazı tipi stili veya hizalama) kendi veri nesnenize kopyalayın.
{{% /alert %}}

## **Kamera için Effective Özelliklerini Al**

Aspose.Slides, bir kameranın effective özelliklerini almanıza olanak tanır. [ICameraEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icameraeffectivedata/) arayüzü, effective kamera özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ICameraEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icameraeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformateffectivedata/) aracılığıyla ortaya konur ve bu da [IThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/) için effective değerler sağlar.

Aşağıdaki kod örneği, kamera için effective özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3B biçimlendirmeye sahip olduğunu varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Işık Kiti için Effective Özelliklerini Al**

Aspose.Slides, bir ışık kitinin (light rig) effective özelliklerini almanıza olanak tanır. [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilightrigeffectivedata/) arayüzü, effective ışık kiti özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilightrigeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformateffectivedata/) aracılığıyla ortaya konur ve bu da [IThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/) için effective değerler sağlar.

Aşağıdaki kod örneği, ışık kitinin effective özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3B biçimlendirmeye sahip olduğunu varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Bevel Şekli için Effective Özelliklerini Al**

Aspose.Slides, bir şekil bevel'in effective özelliklerini almanıza olanak tanır. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapebeveleffectivedata/) arayüzü, bir şeklin effective yüzey rahatlatma özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapebeveleffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformateffectivedata/) aracılığıyla ortaya konur ve bu da [IThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/) için effective değerler sağlar.

Aşağıdaki kod örneği, bir şeklin üst bevel özelliklerinin effective olarak nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3B biçimlendirmeye sahip olduğunu varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Metin Çerçevesi için Effective Özelliklerini Al**

Aspose.Slides kullanarak bir metin çerçevesinin effective özelliklerini alabilirsiniz. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformateffectivedata/) arayüzü, effective metin çerçevesi biçimlendirme özelliklerini içerir.

Aşağıdaki kod örneği, effective metin çerçevesi biçimlendirme özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir metin çerçevesi içeren bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) olduğunu varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Metin Stili için Effective Özelliklerini Al**

Aspose.Slides kullanarak bir metin stilinin effective özelliklerini alabilirsiniz. [ITextStyleEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextstyleeffectivedata/) arayüzü, effective metin stili özelliklerini içerir.

Aşağıdaki kod örneği, effective metin stili özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir metin çerçevesi içeren bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) olduğunu varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Effective Yazı Yüksekliği Değerini Al**

Aspose.Slides kullanarak effective yazı yüksekliğini alabilirsiniz. Aşağıdaki kod, farklı sunum yapı seviyelerinde local yazı yüksekliği değerleri ayarlandıktan sonra bir bölümün effective yazı yüksekliğinin nasıl değiştiğini gösterir.

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

## **Tablo için Effective Doldurma Biçimini Al**

Aspose.Slides kullanarak farklı tablo bölümleri için effective doldurma biçimlendirmesini alabilirsiniz. [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifillformateffectivedata/) arayüzü, effective doldurma biçimlendirme özelliklerini içerir. Hücre biçimlendirmesi, satır biçimlendirmesinden, satır biçimlendirmesi sütun biçimlendirmesinden ve sütun biçimlendirmesi bütün tablo biçimlendirmesinden daha yüksek önceliğe sahiptir.

Sonuç olarak, tablo hücresini çizmek için [ICellFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icellformateffectivedata/) özellikleri kullanılır. Aşağıdaki kod örneği, farklı tablo bölümleri için effective doldurma biçimlendirmesinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itable/) olduğunu varsayar.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **SSS**

**`getEffective()` bir anlık görüntü (snapshot) döndürür mü?**  
Her zaman değil. Effective veriler, kalıtım uygulandıktan sonra hesaplanan biçimlendirmeyi temsil eder, ancak bazı effective veri nesneleri dahili olarak önbelleğe alınabilir. Sonraki bir `getEffective()` çağrısı, biçimlendirmeyi yeniden hesaplayabilir ve önbellekteki verileri yenileyebilir, bu nedenle daha önce elde edilen nesne dayanıklı bir anlık görüntü olarak ele alınmamalıdır.

**Effective özellikleri ne zaman tekrar okumalıyım?**  
Yerel biçimlendirme, üst stiller, düzen biçimlendirmesi, ana biçimlendirme veya sunum düzeyindeki varsayılanlar değiştirildikten sonra `getEffective()` metodunu tekrar çağırın. Bir sonraki çağrı, biçimlendirme hiyerarşisini yeniden değerlendirir ve mevcut effective sonucu döndürür.

**Bir düzen/ana slaytı değiştirmek veya kaldırmak, zaten alınmış olan effective özellikleri etkiler mi?**  
Evet, ancak değişiklik bir sonraki `getEffective()` çağrısında yansıtılır. Bir üst biçimlendirme kaynağı değiştirildiğinde veya kaldırıldığında, daha önce elde edilen effective veriler artık güncel olmayabilir. `getEffective()` tekrar çağrıldığında, Aspose.Slides biçimlendirme ağacını yeniden değerlendirir ve ortaya çıkan yazı tipleri, renkler, boyutlar veya diğer değerler değişebilir.

**Effective veri nesneleri aracılığıyla değerleri değiştirebilir miyim?**  
Hayır. Effective veri nesneleri hesaplanan değerleri sunar. Değişiklikleri yerel biçimlendirme nesnelerinde yapın ve ardından effective değerleri tekrar alın.

**Bir özellik şekil düzeyinde, düzen/ana slaytta veya küresel ayarlarda ayarlanmamışsa ne olur?**  
Effective değer, PowerPoint ve Aspose.Slides varsayılanlarını içeren varsayılan mekanizma tarafından belirlenir. Bu çözülmüş değer, mevcut effective verinin bir parçası haline gelir.

**Effective bir yazı değeri üzerinden, hangi düzeyin boyutu ya da yazı tipini sağladığını söyleyebilir miyim?**  
Doğrudan değil. Effective veri nihai değeri döndürür. Kaynağı bulmak için, bölüm, paragraf, metin çerçevesi ve düzen, ana ve sunum düzeyindeki metin stillerindeki local değerleri kontrol edin; ilk açık tanımın göründüğü yeri belirleyin.

**Effective değerler bazen local değerlerle neden aynı görünüyor?**  
Çünkü yerel değer nihai oldu (daha üst düzey bir kalıtıma ihtiyaç yoktu). Bu durumda, effective değer yerel değerle aynı olur.

**Effective özellikleri ne zaman kullanmalı, ne zaman sadece local özelliklerle çalışmalıyım?**  
Tüm kalıtım uygulandıktan sonra "render edildiği gibi" sonucu elde etmeniz gerektiğinde effective verileri kullanın; örneğin renkleri, girintileri veya boyutları hizalamak için. Bu değerleri sonraki biçimlendirme değişikliklerinden bağımsız olarak korumanız gerekiyorsa, gerekli özellikleri kendi nesnenize kopyalayın. Belirli bir düzeyde biçimlendirme değişikliği yapmanız gerektiğinde, local özellikleri değiştirin ve ardından gerekiyorsa sonucu doğrulamak için effective verileri tekrar okuyun.