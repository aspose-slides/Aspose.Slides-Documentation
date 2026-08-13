---
title: Android'de Sunumlardan Şekil Etkin Özelliklerini Al
linktitle: Etkin Özellikler
type: docs
weight: 50
url: /tr/androidjava/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık sistemi
- kırma kenarı şekli
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android Java aracılığıyla, kesin PowerPoint renderlemesi için etkin şekil özelliklerini hesaplar ve uygular."
---
## **Genel Bakış**

Bu konu **yerel** ve **etkin** özellikleri arasındaki farkı açıklar. Yerel değerler, belirli bir biçimlendirme seviyesinde doğrudan ayarlanan değerlerdir; örneğin:

1. Bir slayttaki bölüm (portion) özellikleri.  
1. Bir düzen ya da ana slaytta prototip şekil metin stilleri, bölümün metin çerçevesi şekli bir stile sahip olduğunda.  
1. Bir sunumdaki global metin ayarları.

Yerel değerler herhangi bir seviyede tanımlanabilir veya atlanabilir. Aspose.Slides, son “görünmüş” biçimlendirmeye ihtiyaç duyduğunda, kalıtım zincirini çözer ve **etkin** değerleri döndürür. Bu değerlere, yerel format nesnesi üzerinde `getEffective()` metodunu çağırarak ulaşabilirsiniz.

Aşağıdaki örnek, etkin değerlerin nasıl alınacağını gösterir. İlk slaydın ilk şeklinin bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) olduğunu ve bir metin çerçevesi ile en az bir bölüm içerdiğini varsayar.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
Etkin biçimlendirme verileri, kalıtım uygulandıktan sonra hesaplanmış mevcut biçimlendirmeyi temsil eder. Mevcut uygulamada, [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iportionformateffectivedata/) gibi bazı etkin veri nesneleri dahili olarak önbelleğe alınabilir. Üst veya kalıtılmış biçimlendirme değiştirildikten sonra `getEffective()` metodunu yeniden çağırmak, önbelleğe alınan verileri yenileyebilir ve daha önce elde edilen nesne artık önceki durumu temsil etmeyebilir. Etkin değerleri daha sonraki yeniden kullanım için saklamanız gerekiyorsa, yazı tipi yüksekliği, dolgu rengi, yazı tipi stili veya hizalama gibi gerekli özellikleri kendi veri nesnenize kopyalayın.
{{% /alert %}}

## **Bir Kamera için Etkin Özellikleri Al**

Aspose.Slides, bir kameranın etkin özelliklerini almanıza olanak tanır. [ICameraEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icameraeffectivedata/) arayüzü, etkin kamera özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ICameraEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icameraeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformateffectivedata/) aracılığıyla sunulur ve [IThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/) için etkin değerleri sağlar.

Aşağıdaki kod örneği, kameranın etkin özelliklerinin nasıl alınacağını gösterir. İlk slaydın ilk şeklinin 3D biçimlendirmeye sahip olduğunu varsayar.

```java
import com.aspose.slides.*;

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

## **Bir Işık Sistemi için Etkin Özellikleri Al**

Aspose.Slides, bir ışık sisteminin (light rig) etkin özelliklerini almanıza olanak tanır. [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilightrigeffectivedata/) arayüzü, etkin ışık sistemi özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilightrigeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformateffectivedata/) aracılığıyla sunulur ve [IThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/) için etkin değerleri sağlar.

Aşağıdaki kod örneği, ışık sistemi için etkin özelliklerin nasıl alınacağını gösterir. İlk slaydın ilk şeklinin 3D biçimlendirmeye sahip olduğunu varsayar.

```java
import com.aspose.slides.*;

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

## **Bir Kırma Kenarı (Bevel) Şekli için Etkin Özellikleri Al**

Aspose.Slides, bir şekil kırma kenarı (bevel) için etkin özellikleri almanıza olanak tanır. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapebeveleffectivedata/) arayüzü, bir şeklin yüzey kabartma özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapebeveleffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformateffectivedata/) aracılığıyla sunulur ve [IThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/) için etkin değerleri sağlar.

Aşağıdaki kod örneği, bir şeklin üst kırma kenarı için etkin özelliklerin nasıl alınacağını gösterir. İlk slaydın ilk şeklinin 3D biçimlendirmeye sahip olduğunu varsayar.

```java
import com.aspose.slides.*;

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

## **Bir Metin Çerçevesi için Etkin Özellikleri Al**

Aspose.Slides kullanarak bir metin çerçevesinin etkin özelliklerini alabilirsiniz. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformateffectivedata/) arayüzü, etkin metin çerçevesi biçimlendirme özelliklerini içerir.

Aşağıdaki kod örneği, etkin metin çerçevesi biçimlendirme özelliklerinin nasıl alınacağını gösterir. İlk slaydın ilk şeklinin bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

```java
import com.aspose.slides.*;

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

## **Bir Metin Stili için Etkin Özellikleri Al**

Aspose.Slides kullanarak bir metin stilinin etkin özelliklerini alabilirsiniz. [ITextStyleEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextstyleeffectivedata/) arayüzü, etkin metin stili özelliklerini içerir.

Aşağıdaki kod örneği, etkin metin stili özelliklerinin nasıl alınacağını gösterir. İlk slaydın ilk şeklinin bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

```java
import com.aspose.slides.*;

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

## **Etkin Yazı Tipi Yüksekliği Değerini Al**

Aspose.Slides kullanarak etkin yazı tipi yüksekliğini alabilirsiniz. Aşağıdaki kod, bir bölümün etkin yazı tipi yüksekliğinin, farklı sunum yapısı seviyelerinde yerel yazı tipi yüksekliği değerleri ayarlandıktan sonra nasıl değiştiğini gösterir.

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

## **Bir Tablo için Etkin Dolgu Biçimini Al**

Aspose.Slides kullanarak farklı tablo bölümleri için etkin dolgu biçimlendirmesini alabilirsiniz. [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifillformateffectivedata/) arayüzü, etkin dolgu biçimlendirme özelliklerini içerir. Hücre biçimlendirmesi, satır biçimlendirmesinden, satır biçimlendirmesi sütun biçimlendirmesinden ve sütun biçimlendirmesi tüm tablo biçimlendirmesinden daha yüksek önceliğe sahiptir.

Sonuç olarak, tablo hücresini çizmek için [ICellFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icellformateffectivedata/) özellikleri kullanılır. Aşağıdaki kod örneği, farklı tablo bölümleri için etkin dolgu biçimlendirmesinin nasıl alınacağını gösterir. İlk slaydın ilk şeklinin bir [ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itable/) olduğunu varsayar.

```java
import com.aspose.slides.*;

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

### `getEffective()` bir anlık görüntü (snapshot) döndürür mü?

Her zaman değil. Etkin veri, kalıtım uygulandıktan sonra hesaplanan biçimlendirmeyi temsil eder, ancak bazı etkin veri nesneleri dahili olarak önbelleğe alınabilir. Ardışık bir `getEffective()` çağrısı biçimlendirmeyi yeniden hesaplayabilir ve önbellekteki verileri yenileyebilir; bu yüzden daha önce elde edilen nesne kalıcı bir anlık görüntü olarak ele alınmamalıdır.

### Etkin özellikleri ne zaman tekrar okumalıyım?

Yerel biçimlendirme, üst stiller, düzen biçimlendirmesi, ana biçimlendirme veya sunum düzeyindeki varsayılanlar değiştirildikten sonra `getEffective()` metodunu tekrar çağırın. Sonraki çağrı biçimlendirme hiyerarşisini yeniden değerlendirir ve o anki etkin sonucu döndürür.

### Bir düzen/ana slayt değiştirildiğinde ya da kaldırıldığında, zaten alınmış olan etkin özellikler etkilenir mi?

Evet, ancak değişiklik bir sonraki `getEffective()` çağrısında yansıtılır. Bir üst biçimlendirme kaynağı değiştirilir veya kaldırılırsa, daha önce elde edilen etkin veriler eski olabilir. `getEffective()` tekrar çağrıldığında Aspose.Slides biçimlendirme ağacını yeniden değerlendirir ve sonuçta oluşan yazı tipleri, renkler, boyutlar vb. değişebilir.

### Etkin veri nesneleri üzerinden değerleri değiştirebilir miyim?

Hayır. Etkin veri nesneleri yalnızca hesaplanmış değerleri gösterir. Değişiklikleri yerel biçimlendirme nesnelerinde yapın ve ardından etkin değerleri tekrar alın.

### Bir özellik şekil seviyesinde, düzen/ana slaytta ya da global ayarlarda hiç ayarlanmadıysa ne olur?

Etkin değer, PowerPoint ve Aspose.Slides varsayılanlarını içeren varsayılan mekanizma tarafından belirlenir. Bu çözülen değer, mevcut etkin verinin bir parçası haline gelir.

### Etkin bir yazı tipi değerinden, boyutu ya da tipografiyi hangi seviyenin sağladığını anlayabilir miyim?

Doğrudan değil. Etkin veri nihai değeri döndürür. Kaynağı bulmak için bölüm, paragraf, metin çerçevesi ve düzen, ana ve sunum seviyelerindeki metin stillerindeki yerel değerleri kontrol edin; ilk açık tanımın nerede ortaya çıktığını görebilirsiniz.

### Neden etkin değerler bazen yerel değerlerle aynı görünüyor?

Çünkü yerel değer, nihai değer haline gelmiş (daha üst seviyede bir kalıtım gerekmediği) ve bu durumda etkin değer yerel değerle aynı olur.

### Etkin özellikleri ne zaman, yerel özellikleri ne zaman kullanmalıyım?

Tüm kalıtım uygulandıktan sonra “görünüşte” elde edilen sonuca ihtiyacınız olduğunda etkin verileri kullanın; örneğin renkleri, girintileri veya boyutları hizalamak için. Bu değerleri daha sonraki biçimlendirme değişikliklerinden bağımsız olarak korumanız gerekiyorsa, gerekli özellikleri kendi nesnenize kopyalayın. Belirli bir seviyede biçimlendirme değişikliği yapmanız gerektiğinde, yerel özellikleri değiştirin ve gerektiğinde sonuçları doğrulamak için etkin verileri tekrar okuyun.