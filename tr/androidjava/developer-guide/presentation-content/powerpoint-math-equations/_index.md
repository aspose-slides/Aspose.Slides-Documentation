---
title: Android'de PowerPoint Sunumlarına Matematik Denklemleri Ekle
linktitle: PowerPoint Matematik Denklemleri
type: docs
weight: 80
url: /tr/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin, OMML desteği, biçimlendirme kontrolleri ve açık Java kod örnekleri sunar."
---
## **Genel Bakış**

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak depolar. Aspose.Slides for Android via Java ile aynı türde matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve formatlanmış matematik blokları.

PowerPoint'ta, kullanıcılar genellikle denklemleri **Insert > Equation** menüsünden ekler:

![PowerPoint Ekle sekmesi, Equation komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir matematik metni olur:

![Düzenlenebilir bir matematik denklemi içeren bir PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- Matematik şekli, [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) ile oluşturulan, denklemi içeren şekildir.
- [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) şekil metin çerçevesi içinde matematik içeriğini depolar.
- [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunaklı tutmak için [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) ve [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/)’in akıcı metodlarını kullanır.

MathML dışa aktarma senaryoları için, [Android'da Sunumlardan Matematik Denklemlerini Dışa Aktarma](/slides/tr/androidjava/exporting-math-equations/) sayfasına bakın.

## **Denklem Oluşturma**

Bu örnek, bir matematik şekli oluşturmak için [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) kullanır ve Pisagor teoremini ekler:

![c kare = a kare + b kare denklemi](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) erişin, [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) çağırın ve ona matematik blokları ya da matematik öğeleri ekleyin.
{{% /alert %}}

## **Kesir Ekleme**

[divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) kullanarak bir kesir oluşturun. [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/) ile bir kesir stili seçebilirsiniz.

![x'e bölünen bir kesiri gösteren eğik bir matematik kesiri](powerpoint-math-equations_4.png)

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

Yığılmış bir kesir için, [MathFractionTypes.Bar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/#Bar) kullanın:

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Kök Ekleme**

[radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) kullanarak karekök, küpkök ya da diğer kökleri oluşturun. Mevcut öğe temel olur, argüman derece olur.

![Kök işaretinin altında x bulunan n'inci dereceli bir kök ifadesi](powerpoint-math-equations_5.png)

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

### **Karekökün Derecesini Gösterme veya Gizleme**

Karekök, açık bir 2 gösterebilir ya da geleneksel √x notasyonunu kullanabilir. [setHideDegree](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathradical/#setHideDegree-boolean-) metodu, [IMathRadical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathradical/) içinde hangi formun görüneceğini kontrol eder. Her iki form da derecesi 2 ve radikand x'i düzenlenebilir denklemde tutar.

![Aynı karekök, solda derece görünürken sağda gizli](square-root-degree.png)

Örnek aynı karekökü iki kez kaydeder. `visible-degree.pptx` dosyasında 2 görünür. `hidden-degree.pptx` dosyasında ise gizlidir.

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

[asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) veya [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) kullanarak `sin(x)`, `log(x)` gibi fonksiyonları ya da özel fonksiyon adlarını ekleyin. Limitler için, `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/) içine koyun veya [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-) kullanın.

![x'in sonsuza doğru limit değeri](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Özel bir fonksiyon adı için, fonksiyon adını mevcut öğe yapın ve [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) çağırarak argümanını verin:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-ary Operatörler ve İntegraller Ekleme**

[nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) kullanarak toplamlar, birleşimler, kesişimler ve diğer büyük operatörleri ekleyin. [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) kullanarak integralleri ekleyin. Her iki metod da alt ve üst limitleri ayarlamanıza izin verir.

![Alt ve üst limitli bir toplam](powerpoint-math-equations_7.png)

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

N-ary operatörler büyük operatörler için, isteğe bağlı limitlerle birlikte kullanılır. `+`, `-`, `=` gibi basit operatörler genellikle [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) olarak eklenir ve ifadeye birleştirilir.

İntegral için, [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) kullanın:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Matris Ekleme**

[MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) satır ve sütunlar için kullanılır. Matrisler varsayılan olarak parantez içermez, bu yüzden parantez, köşeli parantez ya da süslü parantez gerektiğinde matrisi sarın.

![Bir boş hücreli iki satırlı matematik matrisi](powerpoint-math-equations_10.png)

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

Lineer cebir dersi, `matrix.pptx` içindeki katsayı matrisini önceki örnekle kaydettiğini varsayalım. Sonraki egzersiz için, ilk denklemi koruyun, ikinciyi iki yeni denkleme değiştirin ve değişken setini güncelleyin. Mevcut matrisi [IMathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/) aracılığıyla açarak hâlâ geçerli katsayıları koruyun.

![Orijinal iki satırlı katsayı matrisi, ilk satır 1, x ve boş hücre, ikinci satır x, 2 ve y](matrix-before-edit.png)

Satır ve sütun indeksleri sıfırdan başlar ve her çağrıda matrisin o anki durumuna atıfta bulunur. İndeks 1'den önce bir satır eklemek, orijinal ikinci satırı indeks 2'ye taşır. İndeks 2'den sonra eklemek bir satır ekler. Satır 2'yi silmek, orijinal ikinci denklemi kaldırır ve eklenen satırı bir konuma yukarı taşır. Sütunlar da aynı şekilde kayar.

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

    // Yeni hücreler başlangıçta null'dur. Önce sıfır olmayan katsayıları ayarlayın.
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

[setColumnAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/#setColumnAlignment-int-int-) ilk sütunu sola hizalar. [setColumnsAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathmatrix/#setColumnsAlignment-int-long-int-) üç ardışık sütunu sağa hizalar, indeks 1'den başlayarak. `updated-matrix.pptx` dosyasında matris üç denklem ve dört değişkene sahiptir. Orijinal birinci satır katsayıları `1` ve `x` artık birinci ve üçüncü sütunlarda görünür.

![Güncellenmiş üç satırlı matris, satırları 1, 0, x, 0; 12, 1, 0, 0; ve 0, 0, 10, 1 gösteriyor](matrix-after-edit.png)

## **Denklem Dizileri Ekleme**

Yanyana hizalanmış denklemlere veya dikey olarak yığılmış ifadeler gerektiğinde [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) kullanın.

![x'in y'nin üstünde olduğu dikey matematik dizisi](powerpoint-math-equations_11.png)

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

[setBaseJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setBaseJustification-int-) bir dizinin çevresindeki matematik öğelerine göre dikey hizalamasını kontrol eder. Aşağıdaki örnek, ilk satır, dizinin ortası ve son satır ile hizalamayı karşılaştırır.

İşte üç aynı dizi oluşturur, her biri üç satır ve komşu öğeler `A=` ve `=B`. Tüm matematik metni Cambria Math 24 punto ile. Sadece dizi hizalaması değişir.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Aşağıdaki karşılaştırma, PowerPoint'te kaydedilen sunumu gösterir. `A=` ve `=B` öğelerinin konumuna bakın.

![Üst, Orta ve Alt hizalama ve aynı komşu öğelerle PowerPoint'teki denklem dizileri](equation-array-alignment.png)

### **Satır Aralığını Yapılandırma**

[setRowSpacingRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacingRule-int-) dizi içindeki satırların boşluk kuralını seçer. [setRowSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacing-long-) sayısal bir değer sağlar ve ön ayarlı kurallar tarafından yoksayılır.

Kesin aralık için değer puan cinsindendir. Orantılı aralık için yarım satır cinsindendir: örnekte `3` değeri 1.5 satır belirtir. Sayısal bir değer verildiğinde hem özellik hem de kural ayarlanmalıdır; sadece sayısal değeri değiştirmek boşluk kuralını seçmez.

Aşağıdaki örnek aynı denklemler, hizalama ve yazı tipi ayarlarıyla beş sunum kaydeder. İlk üçü ön ayarları kullanır; son ikisi açık değerleri gösterir.

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

Dizi satır aralığı paragraf aralığından bağımsızdır. [setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) ve [setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) kapsayan paragrafın etrafına boşluk ekler, dizi satırları arasına değil. Benzer şekilde, [IMathParagraph.setJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#setJustification-int-) tüm matematik paragrafını yatay olarak konumlandırır; dizi dikey hizalama ayarını değiştirmez.

## **Trigonometrik Fonksiyonlar Ekleme**

Argüman mevcut öğe olduğunda ve fonksiyon adı biliniyorsa [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) kullanın.

![2x'e uygulanan cos trigonometri fonksiyonu](powerpoint-math-equations_6.png)

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

## **Alt ve Üst Simge Ekleme**

Alt ve üst simge yardımcılarını indeksler ve üsler için kullanın. İndeksler temel öğenin sol tarafında görünmesi gerekiyorsa, [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) kullanın.

![Sol tarafı alt simge 1 ve üst simge n ile büyük Y](powerpoint-math-equations_9.png)

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

## **Sınırlayıcılar Ekleme**

[enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) kullanarak bir ifadeyi sınırlayıcıların içine koyun. Birden fazla öğe içeren sınırlayıcı ifadeler için bir ayrım karakteri de ayarlayabilirsiniz.

![x, y ve z'yi dikey çubuklarla ayıran sınırlayıcı ifade](powerpoint-math-equations_13.png)

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

### **Sınırlayıcıları Boyutlandırma ve Hizalama**

[setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) metoduna `true` göndererek parantezlerin uzun bir operand etrafında büyümesini sağlayın, ya da `false` göndererek normal boyutta kalmasını sağlayın. [setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) metodunu iki [MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/) değerinden biriyle kullanın. `Centered` parantezleri matematik ekseni (eşittir işaretinin ortasından geçer) üzerine ortalar. `Match` içeriğe göre hizalar. Her iki ayar sadece sınırlayıcıları etkiler. İçerideki ifade aynı kalır.

Örnek, `x` üssünde bir kesir yerleştirir, böylece ifade tabandan daha fazla yukarı çıkar. Dört denklem aynı parantez ve yazı tipi ayarlarını kullanır.

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

PowerPoint'te, büyüme etkisini görmek için satırları karşılaştırın. Üst satırda, parantezler üssü kapsayacak şekilde büyür ve iki şekil de benzer görünür. Alt satırda büyüme kapalıdır. Sol taraftaki (Centered) daha küçük parantez eşittir işaretiyle hizalanır, sağ taraftaki (Match) ise ifadeyi daha yukarı oturtur.

![Parantez büyümesi açık ve kapalı olarak PowerPoint'te dört denklem, solda Centered ve sağda Match](delimiter-sizing.png)

## **Sınır Kutusu Ekleme**

Bir kesir üzerinde [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) çağırarak tüm ifadeyi çerçeveleyin. Döndürülen [IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) varsayılan olarak dört kenarı gösterir. [setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), ve [setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-) ile bireysel kenarları kaldırabilirsiniz.

Örnek, aynı kesirin altı kopyasını bir slayta yerleştirir. İptal göstermek için tüm dört kenarı gizleyin ve yükselen diyagonal (↗) için [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) , düşen diyagonal (↘) için [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) kullanın. Ayrıca [setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) veya [setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) ile görünür kenarların herhangi bir kombinasyonunu kullanabilirsiniz.

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

![PowerPoint'te altı düzenlenebilir kesir. Üst satır: tam kenar, alt ve sol kenarlar, yükselen diyagonal. Alt satır: düşen diyagonal, yatay çizgi, dikey çizgi ve tam kenar](border-box-fractions.png)

Bu kesirde, yatay çizgi kesir çubuğunun üzerine gelir. Dikey çizgi hem payı hem de paydayı keserken çevre kenarı görünür kalır. Bu çizgiler tüm ifadeyi süsler. Normal metin üzerindeki üstçizgi karakterlerde uygulanır. PowerPoint'te sunumu yeniden açtıktan sonra pay ve payda bağımsız olarak düzenlenebilir.

## **Phantom Öğelerle Görünürlük ve Yerleşimi Kontrol Etme**

Bir ifadeyi [MathPhantom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathphantom/) içinde sararak görünürlüğünü ve denkleme katkı sağladığı boşluğu bağımsız olarak kontrol edebilirsiniz. [IMathPhantom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/) metodları aşağıdakileri kontrol eder:

| Metod | Etkisi |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setShow-boolean-) | `false` göndererek ifadeyi gizleyin. Boyutları hâlâ yerleşime katkıda bulunur, aşağıdaki yöntemler `true` alana kadar. |
| [setZeroWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | İfadenin yatay genişliğini sıfır olarak kabul eder, komşu öğelerin birbirine daha yakın yaklaşmasını sağlar. |
| [setZeroAsc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | Yukarı çıkışını, yani temel çizgi üzerindeki yüksekliği sıfır olarak kabul eder. Bu, komşu öğelerin üzerindeki boşluğu azaltabilir. |
| [setZeroDesc](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | İnişini, yani temel çizgi altındaki derinliği sıfır olarak kabul eder. Bu, bir kesir çubuğu veya diğer içeriğin ifadenin altında komşulara daha yakın olmasını sağlar. |

Temel çizgi, normal matematik harflerinin oturduğu referans çizgidir. İçeriği gizlemek boyutlarını kaldırmaz, boyutu sıfır olarak ayarlamak ifadeyi silmez. Altta yatan ifade [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#getBase--) ile hâlâ erişilebilir. [setShow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathphantom/#setShow-boolean-) metoduna `true` göndererek tekrar görüntüleyebilirsiniz; boyut ayarları değişmeden kalır.

Aşağıdaki örnek, yan yana beş varyant oluşturur: görünür bir kesir, alan ayıran gizli bir kesir ve bir boyutu sıfır olarak ayarlanan üç gizli kesir. Her varyant aynı çevre ifadesi ve 24 punto Cambria Math kullanır. Tüm denklem şekilleri aynı üst konuma sahiptir, gri kılavuzla işaretlenmiştir. Dış kesirin paydasına phantom yerleştirmek, dikey yerleşim değişikliklerini görmeyi kolaylaştırır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LTGRAY);

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

![PowerPoint'te beş denklem, görünür bir kesir, alan ayıran gizli bir kesir ve ZeroWidth, ZeroAsc veya ZeroDesc etkin olan gizli kesirleri karşılaştırıyor](math-phantom.png)

## **Terimleri Gruplama**

[group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-) kullanarak bir ifadeye üstüne veya altına bir gruplama karakteri yerleştirin. Gruplanmış terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi, altında 'any text' etiketi ile gruplanmış](powerpoint-math-equations_15.png)

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

Biçimlendirme yardımcılarını yalnızca formülü netleştirdiği yerlerde kullanın. Örneğin, [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) bir matematik öğesinin üstüne bir çubuk ekler.

![Üst çubuğu olan ABC matematik ifadesi](powerpoint-math-equations_14.png)

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

Mevcut bir denklemin metnini biçimlendirmek için her matematik bloğunun öğe ağacını dolaşın. [IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--) yalnızca doğrudan çocukları döndürür; bu yüzden kesir, üst/alt simgeler, kökler ve diğer iç içe yapı içindeki metne ulaşmak için özyinelemeli olarak çağırın. Başlangıç öğesini ve çocuklarını kontrol ederek [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) olduğunda da dahil edin.

Bu örnek, `input.pptx` dosyasının `z = xᵢ / ∛y` gibi bir denklem içerdiğini varsayar; payda bir kesir içinde alt simge ve payda bir kök içerir. Sadece bloğun üst düzey öğelerini işlemek, kesir içindeki metni atlar. Örnek, slayt metin çerçevelerindeki matematik bölümlerini bulur, bloklara [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) ile erişir ve her metin öğesinin [getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--) metoduyla [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) kullanarak yazı tipini 28 puana ayarlar.

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

Kaydedilen sunum, işlenen her denklemin her seviyesinde güncellenmiş metin biçimlendirmesini içerir, metin içeriği ve matematik yapısını korur.

## **Hızlı Referans**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) |
| Ögeleri birleştirme | [IMathElement.join](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Kesir oluşturma | [IMathElement.divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Üst/alt simge ekleme | [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Fonksiyonlar ekleme | [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Kökler ekleme | [IMathElement.radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Limitler ekleme | [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Sol taraflı üst/alt simgeler ekleme | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Toplamalar ve integraller ekleme | [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Matris ekleme | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| Denklem dizileri ekleme | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Sınırlayıcılar ekleme | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Çubuklar ve kenarlıklar ekleme | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| Terimleri gruplama | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **SSS**

**Mevcut bir PowerPoint denklemini düzenleyebilir miyim?**

Evet. Sunumu açın, bir [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) içeren şekli bulun, [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) çağırın ve o paragraftaki matematik bloklarını güncelleyin.

**Denklemler düzenlenebilir PowerPoint matematiği olarak kaydedilir mi?**

Evet. PPTX olarak kaydettiğinizde, Aspose.Slides denklemi düzenlenebilir Office math içeriği olarak yazar.

**Denklemleri LaTeX'e dışa aktarabilir miyim?**

Evet. Denklemin [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/)’ını [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/)’dan alın ve doğrudan dışa aktarmak için [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--) metodunu çağırın. Tam bir örnek için, [Android'de Sunumlardan Matematik Denklemlerini LaTeX'e Dışa Aktarma](/slides/tr/androidjava/exporting-math-equations/#export-math-equations-to-latex) sayfasına bakın.