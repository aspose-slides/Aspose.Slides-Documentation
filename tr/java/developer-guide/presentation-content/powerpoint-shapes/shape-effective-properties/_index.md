---
title: Java'da Sunumlardan Şekil Etkili Özelliklerini Alın
linktitle: Etkili Özellikler
type: docs
weight: 50
url: /tr/java/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- aydınlatma seti
- kavisli şekil
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'nın, PowerPoint'in hassas bir şekilde işlenmesi için şekil etkili özelliklerini nasıl hesapladığını ve uyguladığını keşfedin."
---
## **Genel Bakış**

Bu konu, **yerel** ve **etkili** özellikler arasındaki farkı açıklar. Yerel değerler, belirli bir biçimlendirme seviyesinde doğrudan ayarlanan değerlerdir, örneğin:

1. Bir slayttaki bölüm (portion) özellikleri.
1. Bir düzen veya ana slaytta, bölümün metin çerçevesi şekli bir taneye sahipse, prototip şekil metin stilleri.
1. Bir sunumdaki küresel metin ayarları.

Yerel değerler herhangi bir seviyede tanımlanabilir veya atlanabilir. Aspose.Slides son “görünmüş” biçimlendirmeye ihtiyaç duyduğunda, kalıtım zincirini çözer ve **etkili** değerleri döndürür. Bu değerlere, yerel format nesnesinde `getEffective` yöntemini çağırarak ulaşabilirsiniz.

Aşağıdaki örnek, etkili değerlerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin, bir metin çerçevesi ve en az bir bölüm içeren bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) olduğunu varsayar.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
Etkili biçimlendirme verileri, kalıtım uygulandıktan sonra hesaplanan mevcut biçimlendirmeyi temsil eder. Mevcut uygulamada, [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPortionFormatEffectiveData) gibi bazı etkili veri nesneleri dahili olarak önbelleğe alınabilir. Üst veya miras alınan biçimlendirme değiştirildikten sonra `getEffective` metodunu tekrar çağırmak önbelleklenen verileri yenileyebilir ve daha önce elde edilen nesne artık önceki durumu temsil etmiyor olabilir. Etkili değerleri daha sonra tekrar kullanmak için saklamanız gerektiğinde, yazı tipi yüksekliği, dolgu rengi, yazı tipi stili veya hizalama gibi gerekli özellikleri kendi veri nesnenize kopyalayın.
{{% /alert %}}

## **Kamera’nın Etkili Özelliklerini Alın**

Aspose.Slides size bir kameranın etkili özelliklerini almanıza izin verir. [ICameraEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICameraEffectiveData) arayüzü, etkili kamera özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ICameraEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICameraEffectiveData) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IThreeDFormatEffectiveData) aracılığıyla sunulur ve bu da [IThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IThreeDFormat) için etkili değerleri sağlar.

Aşağıdaki kod örneği, kamera için etkili özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmesi olduğunu varsayar.

```java
import com.aspose.slides.*;

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

## **Aydınlatma Setinin Etkili Özelliklerini Alın**

Aspose.Slides size bir aydınlatma setinin etkili özelliklerini almanıza izin verir. [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ILightRigEffectiveData) arayüzü, etkili aydınlatma seti özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ILightRigEffectiveData) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IThreeDFormatEffectiveData) aracılığıyla sunulur ve bu da [IThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IThreeDFormat) için etkili değerleri sağlar.

Aşağıdaki kod örneği, aydınlatma seti için etkili özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmesi olduğunu varsayar.

```java
import com.aspose.slides.*;

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

## **Şekil Kavisinin Etkili Özelliklerini Alın**

Aspose.Slides size bir şekil kavisinin etkili özelliklerini almanıza izin verir. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeBevelEffectiveData) arayüzü, bir şeklin etkili yüzey kabartma özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeBevelEffectiveData) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IThreeDFormatEffectiveData) aracılığıyla sunulur ve bu da [IThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IThreeDFormat) için etkili değerleri sağlar.

Aşağıdaki kod örneği, bir şeklin üst kavisinin etkili özelliklerini nasıl alacağınızı gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmesi olduğunu varsayar.

```java
import com.aspose.slides.*;

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

## **Metin Çerçevesinin Etkili Özelliklerini Alın**

Aspose.Slides kullanarak bir metin çerçevesinin etkili özelliklerini alabilirsiniz. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextFrameFormatEffectiveData) arayüzü, etkili metin çerçevesi biçimlendirme özelliklerini içerir.

Aşağıdaki kod örneği, etkili metin çerçevesi biçimlendirme özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin, bir metin çerçevesi içeren bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) olduğunu varsayar.

```java
import com.aspose.slides.*;

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

## **Metin Stilinin Etkili Özelliklerini Alın**

Aspose.Slides kullanarak bir metin stilinin etkili özelliklerini alabilirsiniz. [ITextStyleEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITextStyleEffectiveData) arayüzü, etkili metin stili özelliklerini içerir.

Aşağıdaki kod örneği, etkili metin stili özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin, bir metin çerçevesi içeren bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape) olduğunu varsayar.

```java
import com.aspose.slides.*;

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

## **Etkili Yazı Tipi Yüksekliği Değerini Alın**

Aspose.Slides kullanarak etkili yazı tipi yüksekliğini alabilirsiniz. Aşağıdaki kod, bir bölümün etkili yazı tipi yüksekliğinin, farklı sunum yapısı seviyelerinde yerel yazı tipi yüksekliği değerleri ayarlandığında nasıl değiştiğini gösterir.

```java
import com.aspose.slides.*;

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

## **Bir Tablo İçin Etkili Dolgu Biçimini Alın**

Aspose.Slides kullanarak farklı tablo bölümleri için etkili dolgu biçimlendirmesini alabilirsiniz. [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IFillFormatEffectiveData) arayüzü, etkili dolgu biçimlendirme özelliklerini içerir. Hücre biçimlendirmesi, satır biçimlendirmesinden, satır biçimlendirmesi sütun biçimlendirmesinden ve sütun biçimlendirmesi tüm tablo biçimlendirmesinden daha yüksek önceliğe sahiptir.

Sonuç olarak, tablo hücresini çizerken [ICellFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ICellFormatEffectiveData) özellikleri kullanılır. Aşağıdaki kod örneği, farklı tablo bölümleri için etkili dolgu biçimlendirmesinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITable) olduğunu varsayar.

```java
import com.aspose.slides.*;

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

### `getEffective` bir anlık görüntü (snapshot) döndürür mü?

Her zaman değil. Etkili veri, kalıtım uygulandıktan sonra hesaplanan biçimlendirmeyi temsil eder, ancak bazı etkili veri nesneleri dahili olarak önbelleğe alınabilir. Sonraki bir `getEffective` çağrısı biçimlendirmeyi yeniden hesaplayabilir ve önbelleklenen verileri yenileyebilir, bu yüzden daha önce elde edilen nesne dayanıklı bir anlık görüntü olarak kabul edilmemelidir.

### Etkili özellikleri tekrar ne zaman okumalıyım?

Yerel biçimlendirme, üst stiller, düzen biçimlendirmesi, ana biçimlendirme veya sunum düzeyindeki varsayılanlar değiştirildikten sonra `getEffective` metodunu tekrar çağırın. Bir sonraki çağrı biçimlendirme hiyerarşisini yeniden değerlendirir ve mevcut etkili sonucu döndürür.

### Bir düzen/ana slayt değiştirildiğinde veya kaldırıldığında, zaten alınmış etkili özellikler etkilenir mi?

Evet, ancak değişiklik bir sonraki `getEffective` çağrısında yansıtılır. Üst bir biçimlendirme kaynağı değiştirildiğinde veya kaldırıldığında, daha önce elde edilen etkili veri eski olabilir. `getEffective` tekrar çağrıldığında Aspose.Slides biçimlendirme ağacını yeniden değerlendirir ve ortaya çıkan yazı tipleri, renkler, boyutlar veya diğer değerler değişebilir.

### Etkili veri nesneleri üzerinden değerleri değiştirebilir miyim?

Hayır. Etkili veri nesneleri sadece hesaplanmış değerleri sunar. Değişiklikleri yerel biçimlendirme nesnelerinde yapın ve ardından etkili değerleri tekrar alın.

### Bir özelliğin şekil seviyesinde, düzen/ana slaytta ve küresel ayarlarda hiç ayarlanmamış olması durumunda ne olur?

Etkili değer, PowerPoint ve Aspose.Slides varsayılanlarını içeren varsayılan mekanizma ile belirlenir. Çözülen değer, mevcut etkili verinin bir parçası haline gelir.

### Etkili bir yazı tipi değerinden, boyutu ya da tipi hangi seviyenin sağladığını anlayabilir miyim?

Doğrudan değil. Etkili veri son değeri döndürür. Kaynağı bulmak için bölüm, paragraf, metin çerçevesi ve düzen, ana ve sunum seviyelerindeki metin stillerindeki yerel değerleri kontrol edin; ilk açık tanımın nerede ortaya çıktığını görebilirsiniz.

### Neden etkili değerler bazen yerel değerlerle aynı görünüyor?

Çünkü yerel değer son değer haline gelmiş (daha üst seviyeden bir kalıtım gerektiği olmamış). Bu durumlarda etkili değer yerel değerle aynıdır.

### Etkili özellikleri ne zaman, yerel özellikleri ne zaman kullanmalıyım?

Tüm kalıtım uygulandıktan sonra “görünmüş” sonuca ihtiyacınız olduğunda, renkleri, girintileri veya boyutları hizalamak gibi durumlarda etkili veriyi kullanın. Bu değerleri daha sonraki biçimlendirme değişikliklerinden bağımsız olarak saklamanız gerekiyorsa, gerekli özellikleri kendi nesnenize kopyalayın. Belirli bir seviyede biçimlendirme değiştirmek istiyorsanız, yerel özellikleri değiştirin ve gerekirse sonucu doğrulamak için etkili veriyi tekrar okuyun.