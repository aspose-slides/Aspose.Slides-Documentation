---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in С++ hinzufügen
linktitle: PowerPoint-Mathematische Gleichungen
type: docs
weight: 80
url: /de/cpp/powerpoint-math-equations/
keywords:
- mathematische Gleichung
- mathematisches Symbol
- mathematische Formel
- mathematischer Text
- Mathematische Gleichung hinzufügen
- Mathematisches Symbol hinzufügen
- Mathematische Formel hinzufügen
- Mathematischen Text hinzufügen
- PowerPoint
- Präsentation
- С++
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für C++ einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare C++-Beispielcode."
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und in der Präsentation anzuzeigen. Dazu werden verschiedene mathematische Symbole in PowerPoint dargestellt und können dem Text oder der Gleichung hinzugefügt werden. Dafür wird der mathematische Gleichungskonstruktor in PowerPoint verwendet, der das Erstellen komplexer Formeln unterstützt, wie zum Beispiel:

- Mathematischer Bruch
- Mathematischer Wurzelterm
- Mathematische Funktion
- Grenzen und Logarithmusfunktionen
- N‑stellige Operationen
- Matrix
- Große Operatoren
- Sin‑, Cos‑Funktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das *Einfügen → Gleichung*‑Menü verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Damit wird ein mathematischer Text in XML erzeugt, der in PowerPoint wie folgt dargestellt wird:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt zahlreiche mathematische Symbole zur Erstellung von Gleichungen. Dennoch liefert das Erstellen komplexer Gleichungen in PowerPoint oft kein professionelles Ergebnis. Benutzer, die häufig mathematische Präsentationen erstellen, greifen daher zu Drittanbieter‑Lösungen, um ansprechende Formeln zu erzeugen.

Mit [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/) können Sie mathematische Gleichungen in PowerPoint‑Präsentationen programmgesteuert in C++ verarbeiten. Erzeugen Sie neue mathematische Ausdrücke oder bearbeiten Sie bereits vorhandene. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.


## **Wie man eine mathematische Gleichung erstellt**
Mathematische Elemente werden verwendet, um beliebige mathematische Konstruktionen mit beliebiger Verschachtelung zu bauen. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, dargestellt durch die [**MathBlock** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)‑Klasse. Die [**MathBlock** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)‑Klasse ist im Wesentlichen ein abgegrenzter mathematischer Ausdruck, Formel oder Gleichung. [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) ist ein mathematischer Abschnitt, der mathematischen Text enthält (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion)). [**MathParagraph** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) ermöglicht die Manipulation einer Menge von MathBlocks. Diese Klassen sind der Schlüssel zur Arbeit mit PowerPoint‑Mathe‑Gleichungen über die Aspose.Slides‑API.



Betrachten wir, wie wir die folgende mathematische Gleichung über die Aspose.Slides‑API erzeugen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zuerst eine Form hinzu, die den mathematischen Text enthalten soll:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 


Nach dem Erzeugen enthält die Form standardmäßig bereits einen Absatz mit einem mathematischen Abschnitt. Die [**MathPortion** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion)‑Klasse ist ein Abschnitt, der mathematischen Text enthält. Um auf den mathematischen Inhalt innerhalb der [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) zuzugreifen, verwenden Sie die [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph)‑Variable:

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 


Die [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph)‑Klasse ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von MathBlocks ([**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)), die aus einer Kombination mathematischer Elemente bestehen. Beispiel: Erzeugen Sie einen Bruch und platzieren ihn in der Präsentation:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 


Jedes mathematische Element wird durch eine Klasse repräsentiert, die das [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)‑Interface implementiert. Dieses Interface bietet zahlreiche Methoden zum einfachen Erzeugen mathematischer Ausdrücke. Mit einer einzigen Codezeile lässt sich ein recht komplexer Ausdruck erzeugen. Beispiel: Der Satz des Pythagoras sieht so aus:

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 



Operationen des Interfaces [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) werden in jeder Elementart implementiert, einschließlich der [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block).

Der vollständige Quellcode‑Beispiel:

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


## **Mathematische Elementtypen**
Mathematische Ausdrücke entstehen aus Folgen mathematischer Elemente. Die Folge wird durch einen mathematischen Block dargestellt, und die Argumente der Elemente bilden eine baumartige Verschachtelung.

Es gibt zahlreiche mathematische Elementtypen, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jeder dieser Typen kann in einem anderen Element aggregiert werden – Elemente fungieren also als Container und bilden eine baumartige Struktur. Der einfachste Typ ist ein Element, das keine anderen Elemente enthält.

Jeder Elementtyp implementiert das [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)‑Interface, sodass die gleichen mathematischen Operationen auf unterschiedliche Elemente anwendbar sind.
### **MathematicalText‑Klasse**
Die [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text)‑Klasse repräsentiert mathematischen Text – das Basiselement aller mathematischen Konstruktionen. Sie kann Operanden, Operatoren, Variablen und sonstigen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐
### **MathFraction‑Klasse**
Die [**MathFraction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_fraction)‑Klasse definiert ein Bruchobjekt bestehend aus Zähler und Nenner, getrennt durch einen Bruchstrich. Der Strich kann horizontal oder diagonal sein. Das Objekt wird auch für Stapelfunktionen verwendet, bei denen ein Element über einem anderen steht, ohne Bruchstrich.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical‑Klasse**
Die [**MathRadical**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_radical)‑Klasse definiert die Wurzelfunktion, bestehend aus Basis und optionalem Grad.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction‑Klasse**
Die [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function)‑Klasse definiert eine Funktion eines Arguments. Sie enthält die Methoden [get_Name()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a88b5a46342839d7ef1a8d273694bf0b3) – Funktionsname – und [get_Base()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a765fa6bcbeb9b48730dbcb6504d9b543) – Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator‑Klasse**
Die [**MathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_nary_operator)‑Klasse definiert ein N‑stelliges mathematisches Objekt, z. B. Summation oder Integral. Sie besteht aus einem Operator, einer Basis (oder einem Operanden) und optionalen oberen und unteren Grenzen. Beispiele für N‑stellige Operatoren sind Summation, Union, Schnittmenge, Integral.

Einfachere Operatoren wie + oder ‑ werden nicht hier definiert, sondern durch ein einzelnes [MathematicalText](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text).

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit‑Klasse**
Die [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit)‑Klasse erzeugt eine obere oder untere Grenze. Sie besteht aus Text auf der Grundlinie und verkleinertem Text darüber bzw. darunter. Das Wort „lim“ ist nicht enthalten; Sie können Text oben oder unten platzieren. So entsteht der Ausdruck

![todo:image_alt_text](powerpoint-math-equations_8.png)

mit einer Kombination aus [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) und [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit):

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 
### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement‑Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

Diese Klassen definieren einen Tief- bzw. Hochindex. Sie können Sub‑ und Superscript gleichzeitig links oder rechts setzen; ein einzelner Sub‑ oder Superscript wird nur rechts unterstützt. Der [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element) kann zudem den mathematischen Grad einer Zahl darstellen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix‑Klasse**
Die [**MathMatrix**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_matrix)‑Klasse definiert ein Matrixobjekt, bestehend aus Kindelementen, die in Zeilen und Spalten angeordnet sind. Matrixen besitzen keine eingebauten Begrenzungszeichen; zum Einrahmen sollten Sie ein [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_delimiter)‑Objekt verwenden. Null‑Argumente erzeugen Lücken in der Matrix.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray‑Klasse**
Die [**MathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_array)‑Klasse definiert ein vertikales Array von Gleichungen oder anderen mathematischen Objekten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatierung mathematischer Elemente**
- [**MathBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_border_box)‑Klasse: zeichnet einen rechteckigen oder anderen Rahmen um ein [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_box)‑Klasse: definiert das logische Box‑Verpacken eines mathematischen Elements (z. B. um Zeilenumbrüche zu verhindern).

- [**MathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_delimiter)‑Klasse: definiert ein Begrenzungszeichen mit Öffnungs‑ und Schließzeichen (Klammern, geschweifte Klammern, eckige Klammern, senkrechte Striche) und einem oder mehreren Elementen innen.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_accent)‑Klasse: definiert einen Akzent, bestehend aus Basis und kombinierender diakritischer Markierung.

  Beispiel: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_bar)‑Klasse: definiert eine Balkenfunktion (Über‑ oder Unterbalken).

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_grouping_character)‑Klasse: definiert ein Gruppierungszeichen über oder unter einem Ausdruck, um Beziehungen hervorzuheben.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (via [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)) implementiert das [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)‑Interface. Damit können Sie Operationen auf der bestehenden Struktur ausführen und komplexere Ausdrücke bilden. Alle Methoden akzeptieren entweder ein [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) oder einen String als Argument. Instanzen der [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text)‑Klasse werden implizit aus den übergebenen Strings erzeugt. Die in Aspose.Slides verfügbaren Mathe‑Operationen sind unten aufgeführt.
### **Join‑Methode**
- [Join(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a40d44a0f16d2832ab67decf5e4698b49)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a372375a4f990a157018466622d5d52d9)

Verbindet ein mathematisches Element und bildet einen mathematischen Block. Beispiel:

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 
### **Divide‑Methode**
- [Divide(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae3175481538f5a0a2d6bd3606e7ecfb6)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae1b231db04fff125e5e8c96fd18e608a)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2a1029bda3a198390da3f1b6cb0f677d)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4a19fcb4fcc3a09327793f0ac823e19a)

Erzeugt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Beispiel:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 
### **Enclose‑Methode**
- [Enclose()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab0aa4399c0d506050a7aac9dc7f78804)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a36d623c14594a0926fc8121c42b87bf5)

Umfasst das Element mit angegebenen Zeichen wie Klammern.

``` cpp
/// <summary>
/// Encloses a math element in parenthesis
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// Encloses this element in specified characters such as parenthesis or another characters as framing
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 


Beispiel:

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 
### **Function‑Methode**
- [Function(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afef234e875543a6437a9e2546174ae04)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a320fcf20f060c1a378164558bfa670d4)

Nimmt eine Funktion eines Arguments, wobei das aktuelle Objekt als Funktionsname dient.

``` cpp
/// <summary>
/// Takes a function of an argument using this instance as the function name
/// </summary>
/// <param name="functionArgument">An argument of the function</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 


Beispiel:

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 
### **AsArgumentOfFunction‑Methode**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2f9d0d8b693637f52f8aa9243fd5988e)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac1c703c0ed93628b61e20f622e3d91e9)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac540ffa6839db0e17b1096bc57803b3e)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a93dbde6d11b23e577c427a7d02cf13aa)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a304ca31f530ac1cf6c55dc59995a)

Verwendet das aktuelle Objekt als Argument einer Funktion. Sie können:

- einen String als Funktionsnamen angeben, z. B. “cos”.
- einen vordefinierten Wert aus den Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#adc9da096602adece523e68cb7f302415) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#a161816c6905df993b6c0aae0d98d597b) auswählen, z. B. **MathFunctionsOfOneArgument.ArcSin**.
- die Instanz eines [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) verwenden.

Beispiel:

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 
### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft‑Methoden**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a1610efd629e0fef10f46397c3c671829)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a747a756f05c3a5ebaf96ae4b9853d300)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a3e3613e5c07f1b9df5f59c533d5430d0)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aed4ce1bd63e756b9585214ad832d174a)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acedc512b9952ca9ae6750ff75fd10b1d)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aba884260e8d8b434cbe666444bcb7cdc)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad3a3850ed28e26b627a46a6e7198228f)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afb8cea063303a9e81b6d7f50d9ce8c7c)

Setzt Tief- bzw. Hochindex. Sie können Tief‑ und Hochindex gleichzeitig links oder rechts setzen; ein einzelner Tief‑ oder Hochindex wird nur rechts unterstützt. Der Hochindex kann zudem den mathematischen Grad einer Zahl darstellen.

Beispiel:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 
### **Radical‑Methode**
- [Radical(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aee6b34eb9da73f4c213b93228bfb2fab)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5a144aefdd800d5e564d368e4885ce30)

Definiert die Wurzel eines angegebenen Grades für das gegebene Argument.

Beispiel:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 
### **SetUpperLimit und SetLowerLimit‑Methoden**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a8382894852974a63b242a303ad4973d0)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acbcf1b88a42676de8794c889a4a33354)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a530d7e4e8296ce38fc54b154c059)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2b580a403a87e19f64672cc50e7c53dd)

Setzt obere bzw. untere Grenze. Die Position gibt nur an, ob das Argument über oder unter der Basis liegt.

Betrachten wir den Ausdruck:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) und [MathLimit](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) sowie der Operationen des [IMathElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) erzeugt werden:

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 
### **Nary‑ und Integral‑Methoden**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab850b5a7244cf71b89810555e5f55e26)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a667e2c89d5d77aacc51599177f543f75)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad2a93a7e43548d38e23552f480c85c01)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afed3647d15dc6bd636f5bfa111dfd726)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a27d1ee66c5a31ed7ac1b2d9cc1f6af7d)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aef3e63bdeb956c428b7b1ea385bcdad5)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a16a7f1cd3aa5d09543dfbf0b18bb024e)

Sowohl **Nary** als auch **Integral** erzeugen und geben einen N‑stellig‑Operator zurück, dargestellt durch den Typ [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_nary_operator). Im Nary‑Fall gibt die Aufzählung [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#abd1cf265844d1b4a2e33970bc64d1167) den Operatortyp an (Summation, Union usw.). Im Integral‑Fall wird die Aufzählung [**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#ab12cc959f134cc6693e552d5b7f78607) verwendet.

Beispiel:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 
### **ToMathArray‑Methode**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab3130531dfa9403d42ae02466100ddc1) legt Elemente in ein vertikales Array. Wird diese Methode für ein **MathBlock**‑Objekt aufgerufen, werden alle Kind‑Elemente in das zurückgegebene Array eingefügt.

Beispiel:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 
### **Formatierungsoperationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **Accent** – setzt ein Akzentzeichen (z. B. ein Tilde‑Zeichen) über das Element.
- **Overbar** und **Underbar** – setzen einen Balken über bzw. unter das Element.
- **Group** – fasst Elemente mit einem Gruppierungszeichen (z. B. geschweifte Klammer) zusammen.
- **ToBorderBox** – umschließt das Element mit einem Rahmen.
- **ToBox** – legt das Element in eine logische Box (ohne visuellen Rahmen).

Beispiele:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 

## **FAQ**

**Wie füge ich einer PowerPoint‑Folie eine mathematische Gleichung hinzu?**

Dazu erstellen Sie ein MathShape‑Objekt, das automatisch einen MathPortion enthält. Anschließend holen Sie sich das [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) aus dem [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) und fügen dort [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)-Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erzeugen?**

Ja, Aspose.Slides ermöglicht das Erzeugen komplexer Ausdrücke durch Verschachtelung von MathBlocks. Jedes mathematische Element implementiert das [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/)-Interface, sodass Sie Operationen wie Join, Divide, Enclose usw. kombinieren können.

**Wie kann ich eine bestehende mathematische Gleichung aktualisieren oder ändern?**

Greifen Sie über das [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) auf die vorhandenen MathBlocks zu. Mit Methoden wie Join, Divide, Enclose und anderen können Sie einzelne Elemente der Gleichung ändern. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen zu übernehmen.