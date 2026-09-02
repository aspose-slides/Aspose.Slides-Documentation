---
title: PowerPoint Sunumlarına .NET'te Matematik Denklemleri Ekleme
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
description: "Aspose.Slides for .NET ile PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin; OMML desteği, biçimlendirme kontrolleri ve açık C# kod örnekleri sağlar."
---
## **Genel Bakış**

PowerPoint denklemleri Office Math Markup Language (OMML) olarak depolar. Aspose.Slides for .NET ile aynı türde matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint'te kullanıcılar genellikle denklemleri **Ekle > Denklem** menüsünden ekler:

![PowerPoint Insert sekmesi, Denklem komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir matematik metnidir:

![Düzenlenebilir bir matematik denklemi içeren bir PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides, bu matematik metnini üç ana nesneyle oluşturur:

- Bir matematik şekli, [AddMathShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addmathshape/) ile oluşturulur ve denklemi içerir.
- [MathPortion](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathportion/) şekil metin çerçevesi içinde matematik içeriğini depolar.
- [MathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathematicaltext/) ve [IMathElement](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/) üzerindeki akıcı yöntemleri kullanır.

MathML dışa aktarma senaryoları için, [Export Math Equations from Presentations in .NET](/slides/tr/net/exporting-math-equations/) bölümüne bakın.

## **Denklem Oluşturma**

Bu örnek bir matematik şekli oluşturur ve Pisagor teoremini ekler:

![c² = a² + b² denklemi](powerpoint-math-equations_3.png)

```csharp
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

{{% alert color="primary" %}}
`AddMathShape`, zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk `MathPortion`'a erişin, onun `MathParagraph`'ını alın ve ona matematik blokları veya matematik öğeleri ekleyin.
{{% /alert %}}

## **Kesirler Ekleme**

`Divide` kullanarak bir kesir oluşturun. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathfractiontypes/) ile seçebilirsiniz.

![1/x gösteren eğik bir matematik kesiri](powerpoint-math-equations_4.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Üst üste bir kesir için `MathFractionTypes.Bar` kullanın:

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Kökler Ekleme**

`Radical` kullanarak karekök, küpkök veya diğer kökleri oluşturun. Mevcut öğe taban olur, argüman ise derece olur.

![x, kök işaretinin altında olan n. dereceden kök ifadesi](powerpoint-math-equations_5.png)

```csharp
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

`AsArgumentOfFunction` veya `Function` kullanarak `sin(x)`, `log(x)` gibi fonksiyonları ya da özel fonksiyon adlarını ekleyin. Limitler için, `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathlimit/) içine yerleştirin veya `SetLowerLimit` kullanın.

![x → ∞ iken x'in limiti](powerpoint-math-equations_8.png)

```csharp
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

Özel bir fonksiyon adı için, fonksiyon adını mevcut öğe yapın:

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N-ary Operatörler ve İntegraller Ekleme**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için `Nary` kullanın. İntegraller için `Integral` kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza izin verir.

![Alt ve üst limitleri olan bir toplam](powerpoint-math-equations_7.png)

```csharp
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

N-ary operatörler, isteğe bağlı limitleri olan büyük operatörler içindir. `+`, `-`, `=` gibi basit operatörler genellikle `MathematicalText` olarak eklenir ve ifadeye birleştirilir.

Bir integral için `Integral` kullanın:

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Matriksler Ekleme**

Satır ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathmatrix/) kullanın. Matrisler varsayılan olarak köşeli parantez içermez; bu nedenle parantez, köşeli parantez veya süslü parantez gerektiğinde matrisi kapsayın.

![Bir boş hücreli iki satırlı bir matematik matrisi](powerpoint-math-equations_10.png)

```csharp
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

Hizalanmış denklemler veya dikey bir ifade yığını gerektiğinde `ToMathArray` kullanın.

![y'nin üzerinde x bulunan dikey bir matematik dizisi](powerpoint-math-equations_11.png)

```csharp
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

Argüman mevcut öğe ve fonksiyon adı biliniyorsa `AsArgumentOfFunction` kullanın.

![2x'e uygulanan cos trigonometri fonksiyonu](powerpoint-math-equations_6.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **Alt ve Üst İndeksler Ekleme**

Alt ve üst indeks yardımcılarını indeksler ve üstler için kullanın. Alt indekslerin tabanın sol tarafında görünmesi gerektiğinde `SetSubSuperscriptOnTheLeft` kullanın.

![Sol tarafta 1 alt indeksi ve n üst indeksi olan büyük Y](powerpoint-math-equations_9.png)

```csharp
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

`Enclose` kullanarak bir ifadeyi sınırlayıcıların içine koyun. Birden çok öğe içeren sınırlayıcı ifadeler için ayırıcı karakter de belirleyebilirsiniz.

![x, y ve z'nin dikey çubuklarla ayrıldığı bir sınırlayıcı ifade](powerpoint-math-equations_13.png)

```csharp
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

## **Kenar Kutusu Ekleme**

Denklemin kendisinin kenarlık içine alınması gerektiğinde `ToBorderBox` kullanın.

![a² = b² + c² gösteren kutulu bir denklem](powerpoint-math-equations_12.png)

```csharp
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

Bir ifadeye grup karakteri yerleştirmek için `Group` kullanın. Gruplanmış terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi, altında herhangi bir metin etiketiyle gruplanmış](powerpoint-math-equations_15.png)

```csharp
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

Biçimlendirme yardımcılarını yalnızca formülü netleştirdiği yerlerde kullanın. Örneğin, `Overbar` bir matematik öğesinin üzerine bir çubuk ekler.

![Üstü çizili ABC matematik ifadesi](powerpoint-math-equations_14.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

## **Hızlı Başvuru**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathematicaltext/) |
| Ögeleri birleştirme | [IMathElement.Join](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/join/) |
| Kesirler oluşturma | [IMathElement.Divide](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/divide/) |
| Üst indeks veya alt indeks ekleme | [SetSuperscript](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Fonksiyonlar ekleme | [Function](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Kökler ekleme | [IMathElement.Radical](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/radical/) |
| Limitler ekleme | [SetLowerLimit](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Sol taraf indeksleri ekleme | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Toplamlar ve integraller ekleme | [Nary](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/integral/) |
| Matriksler ekleme | [MathMatrix](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/mathmatrix/) |
| Denklem dizileri ekleme | [ToMathArray](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Sınırlayıcılar ekleme | [Enclose](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/enclose/) |
| Çubuklar ve kenarlıklar ekleme | [Overbar](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Terimleri gruplama | [Group](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathelement/group/) |

## **SSS**

**Mevcut bir PowerPoint denklemini düzenleyebilir miyim?**

Evet. Sunumu açın, `MathPortion` içeren şekli bulun, onun `MathParagraph`'ını alın ve o paragraftaki matematik bloklarını güncelleyin.

**Denklemler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydettiğinizde, Aspose.Slides denklemi düzenlenebilir Office matematik içeriği olarak yazar.

**Denklikleri LaTeX'e dışa aktarabilir miyim?**

Evet. Denklemin [IMathParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathparagraph/) alıp, doğrudan dışa aktarmak için [IMathParagraph.ToLatex](https://reference.aspose.com/slides/tr/net/aspose.slides.mathtext/imathparagraph/tolatex/) çağırın. Tam bir örnek için, [Export Math Equations from Presentations in .NET](/slides/tr/net/exporting-math-equations/#export-math-equations-to-latex) bölümüne bakın.