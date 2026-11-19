---
title: Java'da PowerPoint Sunumlarına Matematik Denklemleri Ekleme
linktitle: PowerPoint Matematik Denklemleri
type: docs
weight: 80
url: /tr/java/powerpoint-math-equations/
keywords:
- matematik denklemi
- matematik sembolü
- matematik formülü
- matematik metni
- matematik denklemi ekle
- matematik sembolü ekle
- matematik formülü ekle
- matematik metni ekle
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin; OMML desteği, biçimlendirme kontrolü ve net Java kod örnekleri sağlar."
---
## **Genel Bakış**

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak saklar. Aspose.Slides for Java ile aynı türde matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint'te kullanıcılar genellikle **Insert > Equation** menüsünden denklemler ekler:

![PowerPoint Ekle sekmesi, Denklem komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir bir matematik metnidir:

![Düzenlenebilir bir matematik denklemi içeren PowerPoint slaydı](powerpoint-math-equations_2.png)

Aspose.Slides, bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- Bir matematik şekli, [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) ile oluşturulur ve denklemi içeren şekildir.
- [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) şeklin metin çerçevesi içinde matematik içeriğini saklar.
- [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) ve [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) akıcı yöntemlerini kullanır.

MathML dışa aktarma senaryoları için [Export Math Equations from Presentations in Java](/slides/tr/java/exporting-math-equations/) bölümüne bakın.

## **Bir Denklem Oluşturma**

Bu örnek, bir matematik şekli oluşturmak için [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) kullanır ve Pisagor teoremini ekler:

![c² = a² + b² denklemi](powerpoint-math-equations_3.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) alın, [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) çağırın ve ona matematik blokları ya da matematik öğeleri ekleyin.
{{% /alert %}}

### **Matematik Bloklarını Birleştirme**

Bir denklemin parçaları bağımsız olarak [IMathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/imathblock/) nesneleri şeklinde oluşturuluyorsa, bunları birleştirmek için [joinBlock](https://reference.aspose.com/slides/java/com.aspose.slides/imathblock/#joinBlock-com.aspose.slides.IMathBlock-) kullanın. Örnekte sol blokta `c² =` ve sağ blokta `a² + b²` oluşturulur. [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-java.lang.String-) üç üst üste gelen gücü düzenlenebilir matematik üst simgeleri olarak yaratır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addMathShape(20, 20, 600, 100);
    IMathPortion mathPortion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IMathParagraph mathParagraph = mathPortion.getMathParagraph();

    MathBlock leftBlock = new MathBlock();
    leftBlock.add(new MathematicalText("c").setSuperscript("2"));
    leftBlock.add(new MathematicalText("="));

    MathBlock rightBlock = new MathBlock();
    rightBlock.add(new MathematicalText("a").setSuperscript("2"));
    rightBlock.add(new MathematicalText("+"));
    rightBlock.add(new MathematicalText("b").setSuperscript("2"));

    IMathBlock combinedBlock = leftBlock.joinBlock(rightBlock);
    mathParagraph.add(combinedBlock);

    presentation.save("equation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[joinBlock](https://reference.aspose.com/slides/java/com.aspose.slides/imathblock/#joinBlock-com.aspose.slides.IMathBlock-) `leftBlock` nesnesini, artık iki parçayı sırayla içeren şekilde döndürür ve `rightBlock` boş bırakılır. Birleştirilmiş bloğu sadece bir kez [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) içine ekleyin. `equation.pptx` yeniden açıldığında paragraf, `c² = a² + b²` ifadesini temsil eden tek bir blok içerir; üç üst simge de matematik üst simgesi olarak korunur.

[add](https://reference.aspose.com/slides/java/com.aspose.slides/imathelementcollection/#add-com.aspose.slides.IMathElement-) metodunu `leftBlock.add(rightBlock)` şeklinde çağırmak, bir bloğu doğrudan diğerinin içine yerleştirmeye çalışır ve `InvalidOperationException` hatası fırlatır.

## **Kesir Ekleme**

Bir kesir oluşturmak için [divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) kullanın. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/) ile seçebilirsiniz.

![x ile bölünmüş bir kesiri gösteren eğik bir matematik kesiri](powerpoint-math-equations_4.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yığılmış bir kesir için [MathFractionTypes.Bar](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/#Bar) kullanın:

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Kök Ekleme**

Kare kök, küp kök ya da başka bir kök oluşturmak için [radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) kullanın. Geçerli öğe taban olur, argüman derece olur.

![x altında kök işareti bulunan n'inci dereceli bir kök ifadesi](powerpoint-math-equations_5.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kare Kökün Derecesini Gösterme veya Gizleme**

Kare kök açıkça 2 gösterebilir ya da geleneksel √x gösterimini kullanabilir. [IMathRadical](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/) üzerindeki [setHideDegree](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/#setHideDegree-boolean-) yöntemi hangi biçimin görüneceğini denetler. Her iki biçim de derece 2 ve radikand x'i düzenlenebilir denklemde tutar.

![Sol tarafta derecesi görünür, sağ tarafta gizli aynı kare kök](square-root-degree.png)

Örnek aynı kare kökü iki kez kaydeder. `visible-degree.pptx` dosyasında 2 görülür. `hidden-degree.pptx` dosyasında ise gizlidir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IMathRadical radical = new MathematicalText("x").radical("2");

    IAutoShape shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    IMathPortion portion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Fonksiyonlar ve Limitler Ekleme**

[asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) ya da [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) kullanarak `sin(x)`, `log(x)` gibi fonksiyonlar ya da özel fonksiyon adları ekleyebilirsiniz. Limitler için `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/mathlimit/) içine koyun veya [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) kullanın.

![x limitinin x sonsuza yaklaştığında limit ifadesi](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Özel bir fonksiyon adı için, mevcut öğeyi fonksiyon adı yapın ve argümanını [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) ile çağırın:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-ary Operatörler ve İntegraller Ekleme**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) kullanın. İntegraller için [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza izin verir.

![Alt ve üst limitli bir toplam ifadesi](powerpoint-math-equations_7.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N-ary operatörler, opsiyonel limitleri olan büyük operatörler içindir. `+`, `-`, `=` gibi basit operatörler genellikle [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) ile eklenir ve ifadeye birleştirilir.

İntegral için [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) kullanın:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Matrisler Ekleme**

Satır ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) kullanın. Matrisler varsayılan olarak köşeli parantez içermez; parantez, köşeli parantez veya süslü parantez gerektiğinde matrisi kendiniz sarın.

![Bir boş hücre içeren iki satırlı bir matematik matrisi](powerpoint-math-equations_10.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Mevcut Bir Matrisi Düzenleme**

Diyelim ki lineer cebir dersi, önceki örnek tarafından kaydedilen `matrix.pptx` dosyasındaki katsayı matrisini içeriyor. Sonraki alıştırmada, ilk denklemi tutun, ikinciyi iki yeni denklemle değiştirin ve değişken setini güncelleyin. Kalan katsayıları korumak için [IMathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/) aracılığıyla mevcut matrisi açın.

![Orijinal iki satırlı katsayı matrisi; ilk satırda 1, x ve boş hücre, ikinci satırda x, 2 ve y](matrix-before-edit.png)

Satır ve sütun indeksleri sıfırdan başlar ve her çağrıda mevcut matrise göre değerlendirilir. İndeks 1'den önce bir satır eklemek, orijinal ikinci satırı indeks 2'ye taşır. İndeks 2'den sonra eklemek bir satır ekler. Satır 2'yi silmek, orijinal ikinci denklemi kaldırır ve eklenen satırı bir konuma yükseltir. Sütunlar da aynı şekilde kayar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("matrix.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IMathPortion portion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IMathMatrix matrix = (IMathMatrix) portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // Yeni hücreler başlangıçta null'dur. Sıfır olmayan katsayıları önce ayarlayın.
    matrix.set_Item(1, 0, new MathematicalText("12"));
    matrix.set_Item(1, 1, new MathematicalText("1"));
    matrix.set_Item(2, 2, new MathematicalText("10"));
    matrix.set_Item(2, 3, new MathematicalText("1"));
    for (int row = 0; row < matrix.getRowCount(); row++) {
        for (int column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/#setColumnAlignment-int-int-) ilk sütunu sola hizalar. [setColumnsAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/imathmatrix/#setColumnsAlignment-int-long-int-) ise indeks 1'den başlayarak üç ardışık sütunu sağa hizalar. `updated-matrix.pptx` dosyasında matris üç denklem ve dört değişken içerir. Orijinal birinci satır katsayıları `1` ve `x` artık birinci ve üçüncü sütunlarda görülür.

![Güncellenmiş üç satırlı matris; satırlar 1, 0, x, 0; 12, 1, 0, 0; ve 0, 0, 10, 1](matrix-after-edit.png)

## **Denklem Dizileri Ekleme**

Yanyana hizalanmış denklemlere ya da dikey bir ifade yığınına ihtiyacınız varsa [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) kullanın.

![x üstünde y bulunan dikey bir matematik dizisi](powerpoint-math-equations_11.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Diziyi Çevreleyen Öğelerle Hizalama**

[setBaseJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setBaseJustification-int-) dizinin, yanındaki matematik öğelerine göre dikey hizalamasını kontrol eder. Aşağıdaki örnek, birincil satır, dizinin ortası ve son satır hizalamasını karşılaştırır.

Aşağıdaki örnek, üç aynı dizi üretir; her biri üç satır ve komşu öğeler `A=` ve `=B` içerir. Tüm matematik metni Cambria Math 24 puan olarak ayarlanmıştır. Sadece dizi hizalaması değişir.

```java
import com.aspose.slides.*;
import java.awt.Color;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);
    
    int[] alignments = { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };
    String[] alignmentNames = { "Top", "Center", "Bottom" };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(alignmentNames[i]);
        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        IAutoShape mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        IMathParagraph mathParagraph = ((IMathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki karşılaştırma, PowerPoint'te kaydedilen sunumu gösterir. Her dizinin yanındaki `A=` ve `=B` konumlarına dikkat edin.

![PowerPoint'te Üst, Ortalanmış ve Alt hizalama gösteren denklem dizileri, aynı komşu öğelerle](equation-array-alignment.png)

### **Satır Aralığını Yapılandırma**

[setRowSpacingRule](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacingRule-int-) dizi içinde satırlar arasındaki boşluk kuralını seçer. [setRowSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacing-long-) sayısal bir değer sağlayarak açık bir boşluk kuralı tanımlar ve önceden tanımlı kurallar tarafından göz ardı edilir.

Tam boşluk için değer puan cinsindendir. Orantılı boşluk için değer yarım satır cinsindendir: örnekteki `3` değeri 1,5 satır anlamına gelir. Açık bir değer belirlerken her iki özelliği de ayarlayın; yalnızca sayısal değeri değiştirmek boşluk kuralını seçmez.

Aşağıdaki örnek aynı denklemler, hizalama ve yazı tipi ayarlarıyla beş sunum kaydeder. İlk üçü önceden tanımlı ayarları, son ikisi ise açık değerleri gösterir.

```java
import com.aspose.slides.*;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
int[] rules = { MathRowSpacingRule.SingleLineGap, MathRowSpacingRule.OneAndAHalfLineGap, MathRowSpacingRule.TwoLineGap, MathRowSpacingRule.Exactly, MathRowSpacingRule.Multiple };
int[] spacingValues = { 0, 0, 0, 20, 3 };
String[] ruleNames = { "SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple" };

for (int i = 0; i < rules.length; i++) {
    String fileName = "equation-array-" + ruleNames[i] + ".pptx";
    Presentation presentation = new Presentation();
    try {
        IAutoShape mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        IMathParagraph mathParagraph = ((IMathPortion) paragraph.getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(spacingValues[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

Dizi satır aralığı, paragraf aralığından ayrı bir ayardır. [setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) ve [setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) ilgili paragrafın etrafına boşluk ekler, dizi satırları arasına değil. Benzer şekilde, [IMathParagraph.setJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#setJustification-int-) tüm matematik paragrafını yatay olarak konumlandırır; dizi dikey hizalama ayarını değiştirmez.

## **Trigonometrik Fonksiyonlar Ekleme**

Fonksiyon adı biliniyorsa ve argüman geçerli öğe ise [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) kullanın.

![2x üzerine uygulanmış cos trigonometrik fonksiyonu](powerpoint-math-equations_6.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alt Simge ve Üst Simge Ekleme**

İndeksler ve üsler için alt ve üst simge yardımcılarını kullanın. İndekslerin tabanın sol tarafında görünmesi gerekiyorsa, [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) kullanın.

![Sol tarafta alt simge 1 ve üst simge n olan büyük Y harfi](powerpoint-math-equations_9.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ayırıcılar Ekleme**

İfade içinde ayırıcılar koymak için [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) kullanın. Birden fazla öğe içeren ayırıcı ifadeler için bir ayırıcı karakteri de ayarlayabilirsiniz.

![x, y ve z elemanlarını dikey çubuklarla ayıran bir ayırıcı ifadesi](powerpoint-math-equations_13.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ayırıcıları Boyutlandırma ve Hizalama**

Parantezlerin yüksek bir operanda göre büyümesini sağlamak için [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) metoduna `true` gönderin; normal boyutta kalmasını istiyorsanız `false` gönderin. [setDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) metodunu iki [MathDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/mathdelimitershape/) değerinden biriyle kullanın. `Centered` parantezleri matematik ekseninde, yani eşittir işaretinin ortasında merkeze alır. `Match` ise içerikle hizalar. Her iki ayar da sadece ayırıcıları etkiler; içteki ifade aynı kalır.

Örnek, `x` tabanının üstüne bir kesir koyar; böylece ifade tabandan daha çok yukarı çıkar. Dört denklem de aynı parantez ve yazı tipi ayarlarını kullanır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (int row = 0; row < 2; row++) {
        for (int column = 0; column < 2; column++) {
            IMathFraction fraction = new MathematicalText("a + b").divide("c + d");
            IMathSuperscriptElement power = new MathematicalText("x").setSuperscript(fraction);
            IMathDelimiter delimiter = power.enclose('(', ')');
            delimiter.setGrowToMatchOperandHeight(row == 0);
            delimiter.setDelimiterShape(column == 0 ? MathDelimiterShape.Centered : MathDelimiterShape.Match);

            IAutoShape mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            MathPortion portion = (MathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            IMathBlock equation = new MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint'te satırları karşılaştırarak büyüme etkisini görün. Üst satırda, parantezler üstteki kesiri kapsayacak şekilde büyür ve iki şekil de benzer görünür. Alt satırda büyüme kapalıdır; sol taraftaki daha küçük parantez (`Centered`) eşittir işaretiyle hizalıdır, sağ taraftakiler (`Match`) ifadenin etrafında daha yüksek oturur.

![Üstte büyüme etkin, altta devre dışı, Solda Centered, Sağda Match olan dört denklem](delimiter-sizing.png)

## **Kenar Kutusu Ekleme**

Bir kesir üzerine [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) çağırarak tüm ifadeyi çerçeveleyin. Döndürülen [IMathBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/) varsayılan olarak dört kenarı da gösterir. Tek tek kenarları kaldırmak için [setHideTop](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), ve [setHideRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideRight-boolean-) kullanın.

Örnek aynı kesirin altı kopyasını bir slayt üzerine koyar. İptali göstermek için dört kenarı da gizleyin ve yükselen bir diyagonal (↗) için [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-), düşen bir diyagonal (↘) için [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) metoduna `true` gönderin. Görünür kenarlarla birlikte herhangi bir kombinasyonda [setStrikethroughHorizontal](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) ya da [setStrikethroughVertical](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) de kullanılabilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    class FractionBuilder {
        IMathBorderBox addFraction(float x, float y, boolean hideBorder) {
            IMathFraction fraction = new MathematicalText("x+1").divide("y+2");
            IMathBorderBox box = fraction.toBorderBox();
            box.setHideTop(hideBorder);
            box.setHideBottom(hideBorder);
            box.setHideLeft(hideBorder);
            box.setHideRight(hideBorder);

            IAutoShape shape = slide.getShapes().addMathShape(x, y, 160, 90);
            MathPortion portion = (MathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(28);
            portion.getMathParagraph().add(new MathBlock(box));
            return box;
        }
    }

    FractionBuilder builder = new FractionBuilder();
    builder.addFraction(10, 10, false);

    IMathBorderBox partial = builder.addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    builder.addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    builder.addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    builder.addFraction(190, 120, true).setStrikethroughHorizontal(true);
    builder.addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Üst satır: tam kenar, alt ve sol kenarlar, yükselen diyagonal; Alt satır: düşen diyagonal, yatay çapraz, dikey çapraz ve tam kenar](border-box-fractions.png)

Bu kesirde, yatay çapraz kesir çubuğu üzerine biner. Dikey çapraz hem payı hem de payda üzerinden geçer; çevre kenarı hâlâ görünür. Bu çizgiler bütün ifadeyi süsler. Normal metin üzerindeki üstü çizme sadece karakterlerde etkilidir. Sunumu PowerPoint'te yeniden açtıktan sonra pay ve payda bağımsız olarak düzenlenebilir.

## **Hayalet Öğelerle Görünürlük ve Düzeni Kontrol Etme**

Bir ifadeyi [MathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/mathphantom/) içinde sararak görünürlüğünü ve denkleme katkısını bağımsız olarak kontrol edebilirsiniz. [IMathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/) yöntemleri aşağıdakileri denetler:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) | `false` göndererek ifadeyi gizleyin. Boyutları hâlâ yerleşime katkıda bulunur, aşağıdaki yöntemler `true` almazsa. |
| [setZeroWidth](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | İfadenin yatay genişliğini sıfır olarak kabul eder; komşu öğeler daha yakın konumlanır. |
| [setZeroAsc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | Üst boşluğu (baseline üzerindeki yükseklik) sıfır kabul eder; komşu öğelerin üzerindeki boşluk azalır. |
| [setZeroDesc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | Alt boşluğu (baseline altındaki derinlik) sıfır kabul eder; kesir çubuğu gibi öğeler daha yakın konumlanır. |

Baseline, normal matematik harflerinin oturduğu referans çizgidir. İçeriği gizlemek boyutları kaldırmaz; bir boyutu sıfır olarak ayarlamak ifadeyi silmez. Temel ifade, [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#getBase--) aracılığıyla hâlâ erişilebilir. Tekrar göstermek için [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) metoduna `true` gönderin; boyut ayarları değişmeden kalır.

Aşağıdaki örnek beş yan yana varyant oluşturur: görünür bir kesir, alan ayıran gizli bir kesir ve bir boyutu sıfır olarak ayarlanan üç gizli kesir. Her varyant aynı çevre ifadesi ve Cambria Math 24 puan kullanır. Tüm denklem şekilleri aynı üst konuma sahiptir; gri kılavuzla işaretlenmiştir. Hayalet öğeyi dış kesirin payına koymak, dikey yerleşim değişikliklerini daha net görmenizi sağlar.

```java
import com.aspose.slides.*;
import java.awt.Color;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    String[] labels = { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

    IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY);

    for (int i = 0; i < labels.length; i++) {
        int left = 10 + i * 200;

        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(labels[i]);

        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        MathematicalText fractionNumerator = factory.createText("a+b");
        MathematicalText fractionDenominator = factory.createText("c+d");
        MathFraction fraction = new MathFraction(fractionNumerator, fractionDenominator);
        MathPhantom phantom = new MathPhantom(fraction);
        phantom.setShow(i == 0);
        phantom.setZeroWidth(i == 2);
        phantom.setZeroAsc(i == 3);
        phantom.setZeroDesc(i == 4);

        MathematicalText leftText = factory.createText("x+");
        MathematicalText rightText = factory.createText("+y");
        IMathBlock numerator = new MathBlock(leftText).join(phantom).join(rightText);
        MathematicalText denominator = factory.createText("z");
        MathFraction equation = new MathFraction(numerator, denominator);

        IAutoShape shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);

        IMathPortion mathPortion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IMathParagraph mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Görünür kesir, alan ayıran gizli kesir ve ZeroWidth, ZeroAsc veya ZeroDesc etkin gizli kesirleri karşılaştıran beş denklem](math-phantom.png)

## **Terimleri Gruplama**

[group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) kullanarak bir gruplama karakterini bir ifadenin üstüne ya da altına yerleştirin. Gruplanmış terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi, altında “any text” etiketiyle gruplanmış](powerpoint-math-equations_15.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Matematik Öğelerini Biçimlendirme**

Yalnızca formülü netleştiren yerlerde biçimlendirme yardımcılarını kullanın. Örneğin, [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--) bir matematik öğesinin üzerine bir çubuk ekler.

![Üstü çizili bir ABC matematik ifadesi](powerpoint-math-equations_14.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Mevcut Bir Denklemde Metni Biçimlendirme**

Mevcut bir denkleme metin biçimlendirmesi uygulamak için her matematik bloğunun öğe ağacını dolaşın. [IMathElement.getChildren](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#getChildren--) yalnızca doğrudan alt öğeleri döndürür; bu yüzden kesirler, üst/alt simgeler, kökler ve diğer iç içe yapılar içindeki metne ulaşmak için yöntemi özyinelemeli olarak çağırın. Başlangıçtaki öğe de [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) olduğunda dahil etmek için öğeyi ve alt öğelerini kontrol edin.

Bu örnek, `input.pptx` dosyasının `z = xᵢ / ∛y` gibi bir denklem içerdiğini varsayar; burada kesir, payda içinde bir alt simge ve payda içinde bir kök bulunur. Yalnızca bloğun üst düzey öğelerini işlemek, kesir içindeki metni kaçırır. Örnek, slayt metin çerçevelerindeki matematik bölümlerini bulur, bloklara [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) aracılığıyla erişir ve her metin öğesinin [getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/#getFormat--) metodundan [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) çağırarak yazı tipini 28 puana ayarlar.

```java
import com.aspose.slides.*;

class MathTextFormatter {
    void formatMathText(IMathElement element) {
        if (element instanceof MathematicalText) {
            MathematicalText text = (MathematicalText) element;
            text.getFormat().setFontHeight(28);
        }

        for (IMathElement child : element.getChildren()) {
            formatMathText(child);
        }
    }
}

MathTextFormatter formatter = new MathTextFormatter();
Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (portion instanceof IMathPortion) {
                        IMathPortion mathPortion = (IMathPortion) portion;
                        for (IMathBlock block : mathPortion.getMathParagraph()) {
                            formatter.formatMathText(block);
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kaydedilen sunum, işlenen her denklemin her seviyesindeki güncellenmiş metin biçimlendirmesini içerir; metin içeriği ve matematik yapısı korunur.

## **Hızlı Referans**

| Task | Main API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) |
| Öğeleri birleştirme | [IMathElement.join](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| Kesir oluşturma | [IMathElement.divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| Üst simge veya alt simge ekleme | [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| Fonksiyon ekleme | [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| Kök ekleme | [IMathElement.radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| Limit ekleme | [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| Sol taraftaki üst/alt simgeler ekleme | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Toplamalar ve integraller ekleme | [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Matris ekleme | [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) |
| Denklem dizileri ekleme | [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) |
| Ayırıcılar ekleme | [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| Çubuk ve kenar kutusu ekleme | [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) |
| Terimleri gruplama | [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **SSS**

**Mevcut bir PowerPoint denklemini düzenleyebilir miyim?**

Evet. Sunumu açın, bir [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) içeren şekli bulun, [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--) metodunu çağırın ve paragraftaki matematik bloklarını güncelleyin.

**Denklikler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydedildiğinde Aspose.Slides, denklemi düzenlenebilir Office matematik içeriği olarak yazar.

**Denklikleri LaTeX'e dışa aktarabilir miyim?**

Evet. Denklemin [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) öğesini, [IMathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/) üzerinden alın ve doğrudan dışa aktarmak için [IMathParagraph.toLatex](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#toLatex--) metodunu çağırın. Tam bir örnek için [Export Math Equations from Presentations in Java](/slides/tr/java/exporting-math-equations/#export-math-equations-to-latex) bölümüne bakın.