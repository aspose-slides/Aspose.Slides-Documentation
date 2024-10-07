---
title: PowerPoint Mathematik Gleichungen
type: docs
weight: 80
url: /cpp/powerpoint-math-equations/
keywords: "PowerPoint Mathematik Gleichungen, PowerPoint Mathematik Symbole, PowerPoint Formel, PowerPoint Mathematik Text"
description: "PowerPoint Mathematik Gleichungen, PowerPoint Mathematik Symbole, PowerPoint Formel, PowerPoint Mathematik Text"
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und sie in der Präsentation anzuzeigen. Dazu werden verschiedene mathematische Symbole in PowerPoint dargestellt und können dem Text oder der Gleichung hinzugefügt werden. Dafür wird der Konstruktor für mathematische Gleichungen in PowerPoint verwendet, der hilft, komplexe Formeln wie:

- Mathematische Brüche
- Mathematische Wurzeln
- Mathematische Funktionen
- Grenzwert- und Logarithmusfunktionen
- N-ary-Operationen
- Matrizen
- Große Operatoren
- Sinus-, Cosinusfunktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Einfügen -> Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Dies erstellt einen mathematischen Text in XML, der in PowerPoint wie folgt angezeigt werden kann:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt viele mathematische Symbole zum Erstellen von Mathematikgleichungen. Es kann jedoch vorkommen, dass die Erstellung komplizierter Mathematikgleichungen in PowerPoint oft kein gutes und professionell aussehendes Ergebnis liefert. Benutzer, die häufig mathematische Präsentationen erstellen müssen, greifen auf die Verwendung von Drittanbieterlösungen zurück, um gut aussehende mathematische Formeln zu erstellen.

Mit der [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/) können Sie programmgesteuert mit mathematischen Gleichungen in PowerPoint-Präsentationen in C++ arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie zuvor erstellte. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.

## **Wie man eine mathematische Gleichung erstellt**
Mathematische Elemente werden verwendet, um beliebige mathematische Konstruktionen mit beliebigem Grad an Verschachtelung zu erstellen. Eine lineare Sammlung von mathematischen Elementen bildet einen mathematischen Block, der durch die [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block) Klasse dargestellt wird. Die [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block) Klasse ist im Wesentlichen ein separater mathematischer Ausdruck, eine Formel oder eine Gleichung. [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) ist ein mathematischer Anteil, der verwendet wird, um mathematischen Text zu halten (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion)). [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) ermöglicht die Manipulation einer Menge von Mathematikblöcken. Die oben genannten Klassen sind der Schlüssel zur Arbeit mit PowerPoint Mathematikgleichungen über die Aspose.Slides API.

Lassen Sie uns sehen, wie wir die folgende mathematische Gleichung über die Aspose.Slides API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zuerst eine Form hinzu, die den mathematischen Text enthält:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 

Nach der Erstellung enthält die Form bereits standardmäßig einen Absatz mit einem mathematischen Anteil. Die [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) Klasse ist ein Anteil, der einen mathematischen Text enthält. Um auf den mathematischen Inhalt innerhalb der [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) zuzugreifen, beziehen Sie sich auf die [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) Variable:

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 

Die [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) Klasse ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von Mathematikblöcken ([**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)), die aus einer Kombination von mathematischen Elementen bestehen. Zum Beispiel, erstellen Sie einen Bruch und platzieren Sie ihn in der Präsentation:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 

Jedes mathematische Element wird durch eine bestimmte Klasse dargestellt, die das [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) Interface implementiert. Dieses Interface bietet viele Methoden, um mathematische Ausdrücke einfach zu erstellen. Sie können einen ziemlich komplexen mathematischen Ausdruck mit einer einzigen Codezeile erstellen. Zum Beispiel würde der Satz des Pythagoras so aussehen:

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 

Die Operationen des Interfaces [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) sind in jedem Typ von Element implementiert, einschließlich des [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block).

Der vollständige Quellcode-Ausschnitt:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
mathParagraph->Add(mathBlock);

pres->Save(u"math.pptx", SaveFormat::Pptx);
``` 

## **Arten mathematischer Elemente**
Mathematische Ausdrücke werden aus Sequenzen mathematischer Elemente gebildet. Die Sequenz mathematischer Elemente wird durch einen mathematischen Block dargestellt, und die Argumente der mathematischen Elemente bilden eine baumartige Verschachtelung.

Es gibt viele mathematische Elementtypen, die verwendet werden können, um einen mathematischen Block zu konstruieren. Jedes dieser Elemente kann in ein anderes Element eingeschlossen (aggregiert) werden. Das heißt, Elemente sind tatsächlich Container für andere und bilden eine baumartige Struktur. Der einfachste Typ von Elementen enthält keine anderen Elemente des mathematischen Textes.

Jeder Typ von Mathematikelement implementiert das [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) Interface, das die Verwendung einer gemeinsamen Menge von Mathematikoperationen auf verschiedenen Typen von Mathematikelementen ermöglicht.
### **MathematicalText Klasse**
Die [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) Klasse stellt einen mathematischen Text dar – das zugrunde liegende Element aller mathematischen Konstruktionen. Mathematischer Text kann Operanden und Operatoren, Variablen und jeden anderen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐
### **MathFraction Klasse**
Die [**MathFraction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_fraction) Klasse spezifiziert das Bruchobjekt, das aus einem Zähler und einem Nenner besteht, die durch eine Bruchlinie getrennt sind. Die Bruchlinie kann horizontal oder diagonal sein, abhängig von den Eigenschaften des Bruchs. Das Bruchobjekt wird auch verwendet, um die Stapelfunktion darzustellen, die ein Element über ein anderes legt, ohne eine Bruchlinie zu verwenden.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical Klasse**
Die [**MathRadical**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_radical) Klasse spezifiziert die radikale Funktion (mathematische Wurzel), die aus einer Basis und einem optionalen Grad besteht.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction Klasse**
Die [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) Klasse spezifiziert eine Funktion eines Arguments. Sie enthält Methoden: [get_Name()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a88b5a46342839d7ef1a8d273694bf0b3) - Funktionsname und [get_Base()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a765fa6bcbeb9b48730dbcb6504d9b543) - Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator Klasse**
Die [**MathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_nary_operator) Klasse spezifiziert ein N-ary mathematisches Objekt, wie Summation und Integral. Es besteht aus einem Operator, einer Basis (oder Operand) und optionalen oberen und unteren Grenzen. Beispiele für N-ary Operatoren sind Summation, Vereinigung, Schnittmenge, Integral.

Diese Klasse umfasst keine einfachen Operatoren wie Addition, Subtraktion usw. Sie werden durch ein einzelnes Textelement - [MathematicalText](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit Klasse**
Die [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) Klasse erstellt die obere oder untere Grenze. Sie spezifiziert das Grenzwertobjekt, das aus Text auf der Baseline und reduziertem Text direkt darüber oder darunter besteht. Dieses Element enthält nicht das Wort "lim", ermöglicht es jedoch, Text oben oder unten im Ausdruck zu platzieren. So wird der Ausdruck 

![todo:image_alt_text](powerpoint-math-equations_8.png)

durch eine Kombination der [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) und [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) Elemente auf folgende Weise erstellt:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

Die folgenden Klassen spezifizieren einen tieferen Index oder einen oberen Index. Sie können sowohl Subscript als auch Superscript gleichzeitig auf der linken oder rechten Seite eines Arguments setzen, jedoch wird einzelnes Subscript oder Superscript nur auf der rechten Seite unterstützt. Das [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element) kann auch verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix Klasse**
Die [**MathMatrix**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_matrix) Klasse spezifiziert das Matrixobjekt, das aus untergeordneten Elementen besteht, die in einer oder mehreren Zeilen und Spalten angeordnet sind. Es ist wichtig zu beachten, dass Matrizen keine eingebauten Trennzeichen haben. Um die Matrix in Klammern zu setzen, sollten Sie das Trennzeichenobjekt - [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_delimiter) verwenden. Nullargumente können verwendet werden, um Lücken in Matrizen zu erstellen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray Klasse**
Die [**MathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_array) Klasse spezifiziert ein vertikales Array von Gleichungen oder anderen mathematischen Objekten.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatierung mathematischer Elemente**
- Die [**MathBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_border_box) Klasse: zeichnet einen rechteckigen oder anderen Rand um das [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Die [**MathBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_box) Klasse: spezifiziert das logische Boxen (Verpacken) des mathematischen Elements. Beispielsweise kann ein gerahmtes Objekt als Operator-Emulator mit oder ohne Ausrichtungspunkt dienen, als Zeilenumbruch oder gruppiert werden, sodass Zeilenumbrüche innerhalb nicht zulässig sind. Zum Beispiel sollte der "==" Operator eingekastet werden, um Zeilenumbrüche zu verhindern.
- Die [**MathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_delimiter) Klasse: spezifiziert das Trennzeichenobjekt, das aus öffnenden und schließenden Zeichen (wie Klammern, geschweifte Klammern, Klammern und senkrechten Linien) besteht und eines oder mehrere mathematische Elemente im Inneren, die durch ein bestimmtes Zeichen getrennt sind. Beispiele: (𝑥2); [𝑥2|𝑦2].
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Die [**MathAccent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_accent) Klasse: spezifiziert die Akzentfunktion, die aus einer Basis und einem kombinierenden diakritischen Zeichen besteht. 

  Beispiel: 𝑎́.

- Die [**MathBar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_bar) Klasse: spezifiziert die Balkenfunktion, die aus einem Basisargument und einem Überstrich oder Unterstrich besteht.
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Die [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_grouping_character) Klasse: spezifiziert ein Gruppensymbol über oder unter einem Ausdruck, normalerweise um die Beziehungen zwischen den Elementen hervorzuheben.
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematische Operationen**
Jedes mathematische Element und mathematischer Ausdruck (über [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)) implementiert das [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) Interface. Es erlaubt Ihnen, Operationen auf der bestehenden Struktur zu verwenden und kompliziertere mathematische Ausdrücke zu bilden. Alle Operationen haben zwei Parametersätze: entweder [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) oder string als Argumente. Instanzen der [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) Klasse werden implizit aus angegebenen Zeichenfolgen erstellt, wenn Zeichenfolgenargumente verwendet werden. Mathematikoperationen, die in Aspose.Slides verfügbar sind, sind unten aufgelistet.
### **Join Methode**
- [Join(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a40d44a0f16d2832ab67decf5e4698b49)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a372375a4f990a157018466622d5d52d9)

Verbindet ein mathematisches Element und bildet einen mathematischen Block. Zum Beispiel:

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 

### **Divide Methode**
- [Divide(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae3175481538f5a0a2d6bd3606e7ecfb6)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae1b231db04fff125e5e8c96fd18e608a)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2a1029bda3a198390da3f1b6cb0f677d)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4a19fcb4fcc3a09327793f0ac823e19a)

Erstellt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Zum Beispiel:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 
### **Enclose Methode**
- [Enclose()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab0aa4399c0d506050a7aac9dc7f78804)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a36d623c14594a0926fc8121c42b87bf5)

Umschließt das Element in angegebenen Zeichen wie Klammern oder einem anderen Zeichen als Rahmen.

``` cpp
/// <summary>
/// Umschließt ein mathematisches Element in Klammern
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// Umschließt dieses Element in angegebenen Zeichen wie Klammern oder anderen Zeichen als Rahmen
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 

Zum Beispiel:

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Function Methode**
- [Function(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afef234e875543a6437a9e2546174ae04)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a320fcf20f060c1a378164558bfa670d4)

Nimmt eine Funktion eines Arguments unter Verwendung des aktuellen Objekts als Funktionsnamen.

``` cpp
/// <summary>
/// Nimmt eine Funktion eines Arguments unter Verwendung dieser Instanz als Funktionsnamen
/// </summary>
/// <param name="functionArgument">Ein Argument der Funktion</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 

Zum Beispiel:

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 
### **AsArgumentOfFunction Methode**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2f9d0d8b693637f52f8aa9243fd5988e)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac1c703c0ed93628b61e20f622e3d91e9)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac540ffa6839db0e17b1096bc57803b3e)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a93dbde6d11b23e577c427a7d02cf13aa)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a304ca31f530ac1cf6c55dc59995a)

Nimmt die angegebene Funktion, wobei die aktuelle Instanz als Argument verwendet wird. Sie können:

- Eine Zeichenfolge als Funktionsnamen angeben, zum Beispiel „cos“.
- Einen der vordefinierten Werte der Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#adc9da096602adece523e68cb7f302415) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#a161816c6905df993b6c0aae0d98d597b) auswählen, zum Beispiel **MathFunctionsOfOneArgument.ArcSin.**
- Die Instanz des [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) auswählen.

Zum Beispiel:

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 
### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft Methoden**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a1610efd629e0fef10f46397c3c671829)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a747a756f05c3a5ebaf96ae4b9853d300)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a3e3613e5c07f1b9df5f59c533d5430d0)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aed4ce1bd63e756b9585214ad832d174a)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acedc512b9952ca9ae6750ff75fd10b1d)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aba884260e8d8b434cbe666444bcb7cdc)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad3a3850ed28e26b627a46a6e7198228f)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afb8cea063303a9e81b6d7f50d9ce8c7c)

Setzt Subscript und Superscript. Sie können Subscript und Superscript gleichzeitig auf der linken oder rechten Seite des Arguments setzen, jedoch wird einzelnes Subscript oder Superscript nur auf der rechten Seite unterstützt. Das **Superscript** kann auch verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 
### **Radical Methode**
- [Radical(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aee6b34eb9da73f4c213b93228bfb2fab)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5a144aefdd800d5e564d368e4885ce30)

Spezifiziert die mathematische Wurzel des gegebenen Grades aus dem angegebenen Argument.

Beispiel:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 
### **SetUpperLimit und SetLowerLimit Methoden**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a8382894852974a63b242a303ad4973d0)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acbcf1b88a42676de8794c889a4a33354)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a530d7e4e8296ce38fc54b154c059)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2b580a403a87e19f64672cc50e7c53dd)

Nimmt die obere oder untere Grenze. Hier geben die obere und untere Grenze einfach die Position des Arguments relativ zur Basis an.

Betrachten wir einen Ausdruck: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) und [MathLimit](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) und Operationen des [IMathElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) wie folgt erstellt werden:

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 
### **Nary und Integral Methoden**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab850b5a7244cf71b89810555e5f55e26)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a667e2c89d5d77aacc51599177f543f75)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad2a93a7e43548d38e23552f480c85c01)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afed3647d15dc6bd636f5bfa111dfd726)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a27d1ee66c5a31ed7ac1b2d9cc1f6af7d)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aef3e63bdeb956c428b7b1ea385bcdad5)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a16a7f1cd3aa5d09543dfbf0b18bb024e)

Sowohl die **Nary** als auch die **Integral** Methoden erstellen und geben den N-ary Operator zurück, der durch den [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_nary_operator) Typ dargestellt wird. In der Nary-Methode gibt die Aufzählung [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#abd1cf265844d1b4a2e33970bc64d1167) den Typ des Operators an: Summation, Vereinigung usw., jedoch ohne Integrale. In der Integral-Methode gibt es die spezialisierte Operation Integral mit der Aufzählung der Integraltypen [**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#ab12cc959f134cc6693e552d5b7f78607).

Beispiel:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 
### **ToMathArray Methode**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab3130531dfa9403d42ae02466100ddc1) platziert Elemente in einem vertikalen Array. Wenn diese Operation für eine **MathBlock** Instanz aufgerufen wird, werden alle untergeordneten Elemente im zurückgegebenen Array platziert.

Beispiel:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 
### **Formatierungsoperationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Die [**Accent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acd0f38691b52fb83294c0da9f3690483) Methode setzt ein Akzentzeichen (ein Zeichen oben auf dem Element).
- Die [**Overbar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5d4780f9be6d0709465f50f5d830d4e3) und [**Underbar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a97d93a1fc79a31f4ffd20d233e06c5a5) Methoden setzen einen Balken oben oder unten.
- Die [**Group**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4662589060e34723455b8164ce556546) Methode platziert in einer Gruppe mithilfe eines Gruppierungszeichens wie einer unteren geschweiften Klammer oder einer anderen.
- Die [**ToBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aa32771655d8931aa8e0b5d3c1c7e160b) Methode platziert in einem Border-Box.
- Die [**ToBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac18b6b70362303cb307862a9aaa7dce2) Methode platziert in einer nicht sichtbaren Box (logische Gruppierung).

Beispiele:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 