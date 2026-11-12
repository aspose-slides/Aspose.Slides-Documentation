---
title: .NET'te PowerPoint Sunumlarına Matematik Denklemleri Ekleme
linktitle: PowerPoint Matematik Denklemleri
type: docs
weight: 80
url: /tr/net/powerpoint-math-equations/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin, OMML desteği, biçimlendirme kontrolleri ve net C# kod örnekleri sağlar."
---
## **Genel Bakış**

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak saklar. Aspose.Slides for .NET ile aynı türde matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint'te kullanıcılar genellikle **Insert > Equation** üzerinden denklemler ekler:

![PowerPoint Ekle sekmesi, Equation komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir matematik metni olur:

![Düzenlenebilir bir matematik denklemi içeren bir PowerPoint slaydı](powerpoint-math-equations_2.png)

Aspose.Slides, bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- Bir matematik şekli, [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) ile oluşturulur ve denklemi içerir.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) şekil metin çerçevesi içinde matematik içeriğini depolar.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) nesnesi içerir.

Aşağıdaki örneklerin çoğu, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) ve [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) akıcı metodlarını kullanır.

MathML dışa aktarma senaryoları için, [Sunumlardan Matematik Denklemlerini Dışa Aktarma (.NET)](/slides/tr/net/exporting-math-equations/) sayfasına bakın.

## **Denklem Oluşturma**

Bu örnek, [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) kullanarak bir matematik şekli oluşturur ve Pisagor teoremini ekler:

![c kare = a kare + b kare denklemi](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}

[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) creates a shape that already contains a math paragraph. Access the first [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), get its [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), and add math blocks or math elements to it.

{{% /alert %}}

## **Kesir Ekleme**

[Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) kullanarak bir kesir oluşturun. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) ile seçebilirsiniz.

![x'e bölünmüş bir kesir gösteren eğik kesir](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Yığılmış bir kesir için [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) kullanın:

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Kök Ekleme**

[Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) kullanarak karekök, küpkök veya diğer kökleri oluşturabilirsiniz. Mevcut öğe temel olur, argüman ise derecesi olur.

![x radikal işareti altında n'inci dereceden bir kök ifadesi](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

## **Fonksiyonlar ve Limitler Ekleme**

[AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) veya [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) kullanarak `sin(x)`, `log(x)` gibi fonksiyonlar veya özel fonksiyon adları ekleyebilirsiniz. Limitler için `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) içine koyun veya [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/) kullanın.

![x'in sonsuza gittiği limit](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

Özel bir fonksiyon adı için, fonksiyon adını mevcut öğe yapın ve argümanıyla birlikte [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) çağırın:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N-ary Operatörler ve İntegraller Ekleme**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) kullanın. İntegraller için [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanızı sağlar.

![Alt ve üst limitli bir toplam](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

N-ary operatörler, isteğe bağlı limitleri olan büyük operatörler içindir. `+`, `-`, `=` gibi basit operatörler genellikle [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) ile eklenir ve ifadeye katılır.

Bir integral için, [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) kullanın:

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Matris Ekleme**

Satırlar ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) kullanın. Matrisler varsayılan olarak köşeli parantez içermez, bu yüzden parantez, köşeli parantez veya süslü parantez gerektiğinde matrisi sarın.

![Bir boş hücreli iki satırlı matematik matrisi](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

## **Denklem Dizileri Ekleme**

Hizalanmış denklemler veya dikey bir ifade yığını gerektiğinde [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) kullanın.

![x'in y'nin üzerinde olduğu dikey matematik dizisi](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

## **Trigonometrik Fonksiyonlar Ekleme**

Argüman mevcut öğe olduğunda ve fonksiyon adı bilindiğinde [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) kullanın.

![2x'e uygulanmış cos trigonometrik fonksiyonu](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **Alt ve Üst Simge Ekleme**

İndeksler ve üsler için alt ve üst simge yardımcılarını kullanın. İndeksler temel öğenin sol tarafında görünmeliyse, [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) kullanın.

![Sol tarafında 1 alt simge ve n üst simge olan büyük Y](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **Sınırlayıcılar Ekleme**

Bir ifadeyi sınırlayıcılar içine koymak için [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) kullanın. Birden fazla öğe içeren sınırlayıcı ifadeler için ayırıcı karakter de ayarlayabilirsiniz.

![x, y ve z'yi dikey çubuklarla ayıran sınırlayıcı ifadesi](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

### **Sınırlayıcıların Boyutu ve Hizalanması**

Parantezlerin uzun bir operand etrafında büyümesi için [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) özelliğini `true` yapın; normal boyutta kalması için `false` yapın. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) iki [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) değerinden birini alır. `Centered` parantezleri matematik ekseninin ortasına, `Match` ise içeriğe göre hizalar. Bu ayarlar sadece sınırlayıcılara etki eder; içteki ifade aynı kalır.

Örnek, `x` üssünde bir kesir koyar ve ifadenin üst satırdaki kısmı alt satırdan daha fazla yükselir. Dört denklemin hepsi aynı parantez ve font ayarlarını kullanır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

void AddExpression(float left, float top, bool grow, MathDelimiterShape shape)
{
    var fraction = new MathematicalText("a + b").Divide("c + d");
    var power = new MathematicalText("x").SetSuperscript(fraction);
    var delimiter = power.Enclose('(', ')');
    delimiter.GrowToMatchOperandHeight = grow;
    delimiter.DelimiterShape = shape;

    var mathShape = slide.Shapes.AddMathShape(left, top, 300, 100);
    var portion = (MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 32;
    var equation = new MathematicalText("y = ").Join(delimiter);
    portion.MathParagraph.Add(equation);
}

AddExpression(20, 20, true, MathDelimiterShape.Centered);
AddExpression(350, 20, true, MathDelimiterShape.Match);
AddExpression(20, 140, false, MathDelimiterShape.Centered);
AddExpression(350, 140, false, MathDelimiterShape.Match);

presentation.Save("delimiter-sizing.pptx", SaveFormat.Pptx);
```

PowerPoint'te, etkisini görmek için satırları karşılaştırın. Üst satırda parantezler üssü sarmak için büyür ve iki şekil de aynı görünür. Alt satırda büyüme kapalıdır; soldaki daha küçük parantez (`Centered`) eşittir işaretine hizalanırken, sağdaki (`Match`) ifadeyi daha yukarıda tutar.

![Üstte büyümesi etkin, altta devre dışı sınırlayıcı büyümesiyle dört denklem; solda Centered, sağda Match](delimiter-sizing.png)

## **Kenarlıklı Kutu Ekleme**

Denklemin kendisinin çerçevelenmesi gerektiğinde [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) kullanın.

![Kare = b kare + c kare gösteren kutulu bir denklem](powerpoint-math-equations_12.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **Terimleri Gruplama**

İfadenin üstüne veya altına bir gruplayıcı karakter koymak için [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) kullanın. Gruplanmış terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi altında herhangi bir metin etiketi ile gruplanmış](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **Matematik Öğelerini Biçimlendirme**

Formülü netleştiren yerlerde sadece biçimlendirme yardımcılarını kullanın. Örneğin, [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) bir matematik öğesinin üstüne çubuk ekler.

![Üst çubuğu olan ABC matematik ifadesi](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

### **Mevcut Bir Denklemede Metni Biçimlendirme**

Mevcut bir denklemin tüm metnini biçimlendirmek için her matematik bloğunun öğe ağacını dolaşın. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) yalnızca doğrudan çocukları döndürür; bu yüzden kesir, üst/alt simge, kök ve diğer iç içe yapılar içindeki metne ulaşmak için yinelemeli olarak çağırın. Başlangıç öğesi de [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) olduğunda dahil edin.

Bu örnek, bir sunumun `z = xᵢ / ∛y` gibi bir denklem içerdiğini varsayar; burada kesir payda üstünde bir alt simge ve payda altında bir kök vardır. Bloğun yalnızca üst düzey öğelerini işlemek, kesir içindeki metni kaçırır. Örnek, slayt metin çerçevelerindeki matematik bölümlerini bulur, [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) aracılığıyla bloklarına erişir ve her metin öğesinin [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) özelliği üzerinden [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) değerini 28 punto olarak ayarlar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape || autoShape.TextFrame == null)
            continue;

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is IMathPortion mathPortion)
                {
                    foreach (var block in mathPortion.MathParagraph)
                        FormatMathText(block);
                }
            }
        }
    }
}

presentation.Save("formatted-equations.pptx", SaveFormat.Pptx);

void FormatMathText(IMathElement element)
{
    if (element is MathematicalText text)
        text.Format.FontHeight = 28;

    foreach (var child in element.GetChildren())
        FormatMathText(child);
}
```

Kaydedilen sunum, işlenen her denklemin her seviyesinde güncellenmiş metin biçimlendirmesini içerirken metin içeriğini ve matematik yapısını korur.

## **Hızlı Başvuru**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Öğeleri birleştirme | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Kesir oluşturma | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Üst simge veya alt simge ekleme | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Fonksiyon ekleme | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Kök ekleme | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Limit ekleme | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Sol taraflı alt/üst simge ekleme | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Toplamalar ve integraller ekleme | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Matris ekleme | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Denklem dizileri ekleme | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Sınırlayıcı ekleme | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Çubuk ve kenarlık ekleme | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Terimleri gruplama | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **SSS**

**Mevcut bir PowerPoint denklemini düzenleyebilir miyim?**

Evet. Sunumu açın, bir [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) içeren şekli bulun, onun [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) öğesini alın ve o paragraftaki matematik bloklarını güncelleyin.

**Denklemler düzenlenebilir PowerPoint matematiği olarak kaydedilir mi?**

Evet. PPTX olarak kaydettiğinizde Aspose.Slides, denklemi düzenlenebilir Office matematik içeriği olarak yazar.

**Denklemleri LaTeX'e dışa aktarabilir miyim?**

Evet. Denklemin [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) öğesini, [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) üzerinden alın ve doğrudan dışa aktarmak için [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) yöntemini çağırın. Tam bir örnek için, [Sunumlardan Matematik Denklemlerini Dışa Aktarma (.NET) #export-math-equations-to-latex](/slides/tr/net/exporting-math-equations/#export-math-equations-to-latex) sayfasına bakın.