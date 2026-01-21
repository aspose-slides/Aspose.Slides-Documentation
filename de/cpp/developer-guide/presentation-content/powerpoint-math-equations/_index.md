---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in C++ hinzufügen
linktitle: PowerPoint Mathegleichungen
type: docs
weight: 80
url: /de/cpp/powerpoint-math-equations/
keywords:
- Mathegleichung
- Mathezeichen
- Matheformel
- Mathetext
- Mathegleichung hinzufügen
- Mathezeichen hinzufügen
- Matheformel hinzufügen
- Mathetext hinzufügen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Mathegleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für C++ einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare C++‑Beispielcodes."
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und in der Präsentation anzuzeigen. Dafür werden verschiedene mathematische Symbole in PowerPoint dargestellt und können dem Text oder der Gleichung hinzugefügt werden. Hierfür wird der Mathe‑Gleichungs‑Konstruktor in PowerPoint verwendet, der beim Erstellen komplexer Formeln wie folgt hilft:

- Mathematischer Bruch
- Mathematischer Radikal
- Mathematische Funktion
- Grenzwerte und Log‑Funktionen
- N‑stellige Operationen
- Matrix
- Große Operatoren
- Sinus‑, Cosinus‑Funktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Einfügen -> Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Damit wird ein mathematischer Text in XML erzeugt, der in PowerPoint wie folgt angezeigt werden kann: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt eine Vielzahl von mathematischen Symbolen zur Erstellung von Gleichungen. Das Erstellen komplizierter mathematischer Gleichungen in PowerPoint führt jedoch häufig nicht zu einem guten und professionell aussehenden Ergebnis. Benutzer, die häufig mathematische Präsentationen erstellen müssen, greifen auf Drittanbieterlösungen zurück, um ansprechende Formeln zu erzeugen.

Mit [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/) können Sie programmgesteuert in C++ mit mathematischen Gleichungen in PowerPoint‑Präsentationen arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie bereits erstellte. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.

## **So erstellen Sie eine mathematische Gleichung**
Mathematische Elemente werden verwendet, um beliebige mathematische Konstruktionen mit beliebiger Verschachtelung zu erstellen. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die Klasse [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) repräsentiert wird. Die [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)‑Klasse ist im Prinzip ein abgegrenzter mathematischer Ausdruck, eine Formel oder Gleichung. [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) ist ein mathematischer Abschnitt, der mathematischen Text enthält (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)). [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) ermöglicht die Manipulation einer Menge von MathBlocks. Die genannten Klassen sind der Schlüssel zur Arbeit mit mathematischen Gleichungen in PowerPoint über die Aspose.Slides‑API.

Schauen wir uns an, wie wir die folgende mathematische Gleichung über die Aspose.Slides‑API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zunächst eine Form hinzu, die den mathematischen Text enthalten wird:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 

Nach dem Erstellen enthält die Form bereits standardmäßig einen Absatz mit einem mathematischen Abschnitt. Die [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/)‑Klasse ist ein Abschnitt, der einen mathematischen Text enthält. Um auf den mathematischen Inhalt innerhalb der [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) zuzugreifen, beziehen Sie sich auf die [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)‑Variable:

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 

Die [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)‑Klasse ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von MathBlocks ([**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)), die aus einer Kombination mathematischer Elemente bestehen. Beispiel: Erstellen Sie einen Bruch und fügen Sie ihn in die Präsentation ein:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 

Jedes mathematische Element wird durch eine Klasse repräsentiert, die das Interface [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) implementiert. Dieses Interface bietet zahlreiche Methoden zum einfachen Erzeugen mathematischer Ausdrücke. Man kann mit einer einzigen Codezeile einen recht komplexen Ausdruck erzeugen. Beispiel: Der Satz des Pythagoras lässt sich so darstellen:

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 

Operationen des Interfaces [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) sind in allen Elementtypen implementiert, einschließlich des [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/).

Vollständiges Beispiel:

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
Mathematische Ausdrücke setzen sich aus Sequenzen mathematischer Elemente zusammen. Die Sequenz wird durch einen mathematischen Block repräsentiert, und die Argumente der Elemente bilden eine baumartige Verschachtelung.

Es gibt zahlreiche mathematische Elementtypen, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jeder dieser Typen kann in einem anderen Element aggregiert werden – die Elemente fungieren also als Container und bilden eine baumartige Struktur. Der einfachste Typ enthält keine weiteren Elemente des mathematischen Textes.

Jeder Elementtyp implementiert das Interface [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/), wodurch ein gemeinsamer Satz von mathematischen Operationen auf unterschiedliche Typen angewendet werden kann.

### **MathematicalText‑Klasse**
Die [**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/)‑Klasse stellt einen mathematischen Text dar – das Grundelement aller mathematischen Konstruktionen. Sie kann Operanden, Operatoren, Variablen und beliebigen linearen Text repräsentieren.

Beispiel: 𝑎=𝑏+𝑐

### **MathFraction‑Klasse**
Die [**MathFraction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfraction/)‑Klasse beschreibt einen Bruch, der aus Zähler und Nenner besteht, getrennt durch einen Bruchstrich. Der Strich kann horizontal oder diagonal sein, abhängig von den Eigenschaften des Bruchs. Die Klasse wird auch für Stapelfunktionen verwendet, bei denen ein Element über einem anderen steht, ohne Bruchstrich.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical‑Klasse**
Die [**MathRadical**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathradical/)‑Klasse definiert die Wurzelfunktion, bestehend aus einer Basis und optional einem Grad.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction‑Klasse**
Die [**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/)‑Klasse definiert eine Funktion eines Arguments. Methoden: [get_Name()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_name/) – Funktionsname und [get_Base()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_base/) – Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator‑Klasse**
Die [**MathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathnaryoperator/)‑Klasse definiert ein N‑stelliges mathematisches Objekt, z. B. Summen‑ oder Integralzeichen. Sie besteht aus einem Operator, einer Basis (oder Operanden) und optionalen oberen sowie unteren Grenzen. Beispiele für N‑stellige Operatoren sind Summation, Vereinigung, Schnittmenge, Integral.

Einfachere Operatoren wie Plus oder Minus werden nicht hier definiert, sondern durch ein einzelnes Text‑Element – [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) – dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit‑Klasse**
Die [**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/)‑Klasse erzeugt eine obere oder untere Grenze. Sie besteht aus Text auf der Grundlinie und verkleinertem Text direkt darüber oder darunter. Das Element enthält nicht das Wort „lim“, ermöglicht jedoch das Platzieren von Text über oder unter dem Ausdruck. So wird der Ausdruck

![todo:image_alt_text](powerpoint-math-equations_8.png)

mittels einer Kombination aus [**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) und [**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) wie folgt erzeugt:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement‑Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Die folgenden Klassen definieren einen tiefen bzw. hohen Index. Man kann gleichzeitig tief- und hochgestellt links oder rechts setzen; ein einzelner tief- oder hochgestellter Index wird nur rechts unterstützt. Der [MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/) kann zudem den mathematischen Grad einer Zahl festlegen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix‑Klasse**
Die [**MathMatrix**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/)‑Klasse definiert ein Matrix‑Objekt, das aus Kindelementen besteht, die in einer oder mehreren Zeilen und Spalten angeordnet sind. Matrixen besitzen keine eingebauten Begrenzungszeichen; um die Matrix in Klammern zu setzen, muss das Begrenzungs‑Objekt [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathdelimiter/) verwendet werden. Null‑Argumente können verwendet werden, um Lücken in der Matrix zu erzeugen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray‑Klasse**
Die [**MathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/matharray/)‑Klasse definiert ein vertikales Array von Gleichungen oder anderen mathematischen Objekten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatierung mathematischer Elemente**
- [**MathBorderBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathborderbox/)‑Klasse: zeichnet eine rechteckige oder andere Umrandung um das [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/).

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbox/)‑Klasse: definiert das logische „Boxen“ (Packaging) des mathematischen Elements. Beispielsweise kann ein eingekapseltes Objekt als Operator‑Emulator mit oder ohne Ausrichtungs­punkt dienen, als Zeilenumbruch‑Punkt oder als Gruppe, die Zeilenumbrüche verhindert. Der Operator „==“ sollte beispielsweise in einer Box liegen, um Zeilenumbrüche zu verhindern.

- [**MathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathdelimiter/)‑Klasse: definiert das Begrenzungs‑Objekt, bestehend aus öffnenden und schließenden Zeichen (z. B. Klammern, geschweifte Klammern, eckige Klammern, senkrechte Striche) und einem oder mehreren mathematischen Elementen innen, getrennt durch ein angegebenes Zeichen. Beispiele: (𝑥2); [𝑥2|𝑦2].

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathaccent/)‑Klasse: definiert die Akzent‑Funktion, bestehend aus einer Basis und einem kombinierenden diakritischen Zeichen.

  Beispiel: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbar/)‑Klasse: definiert die Balken‑Funktion, bestehend aus einem Basis‑Argument und einem Ober‑ oder Unterbalken.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathgroupingcharacter/)‑Klasse: definiert ein Gruppierungszeichen über oder unter einem Ausdruck, normalerweise zur Hervorhebung von Beziehungen zwischen Elementen.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (via [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)) implementiert das Interface [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/). Es ermöglicht die Anwendung von Operationen auf die bestehende Struktur und das Bilden komplexerer Ausdrücke. Alle Operationen besitzen zwei Parameter‑Sätze: entweder [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) oder einen String als Argument. Instanzen der [**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/)-Klasse werden implizit aus den angegebenen Strings erzeugt, wenn String‑Argumente verwendet werden. Mathematische Operationen, die in Aspose.Slides verfügbar sind, werden unten aufgeführt.

### **Join‑Methode**
- [Join(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemstring-method)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemsharedptrimathelement-method)

Fügt ein mathematisches Element hinzu und bildet einen mathematischen Block. Beispiel:

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 

### **Divide‑Methode**
- [Divide(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-method)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-method)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-mathfractiontypes-method)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-mathfractiontypes-method)

Erzeugt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Beispiel:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 

### **Enclose‑Methode**
- [Enclose()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclose-method)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclosechar16_t-char16_t-method)

Umschließt das Element in angegebenen Zeichen, z. B. Klammern oder anderen Rahmenzeichen.

``` cpp
/// <summary>
/// Encloses a math element in parenthesis
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// Encloses this element in specified characters such such as parenthesis or another characters as framing
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 

Beispiel:

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Function‑Methode**
- [Function(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemstring-method)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemsharedptrimathelement-method)

Verwendet das aktuelle Objekt als Funktionsnamen und nimmt ein Funktionsargument.

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
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemstring-method)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsofoneargument-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemstring-method)

Verwendet das aktuelle Objekt als Argument einer Funktion. Sie können:

- Einen String als Funktionsnamen angeben, z. B. „cos“.
- Einen der vordefinierten Werte der Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunctionsofoneargument/) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunctionsoftwoarguments/) auswählen, z. B. **MathFunctionsOfOneArgument.ArcSin**.
- Die Instanz eines [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) übergeben.

Beispiel:

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft‑Methoden**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemstring-method)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemsharedptrimathelement-method)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemstring-method)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemsharedptrimathelement-systemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemsharedptrimathelement-systemsharedptrimathelement-method)

Setzt Tief- bzw. Hochstellung. Man kann Tief- und Hochstellung gleichzeitig links oder rechts setzen; ein einzelner Tief‑ oder Hochstellungs‑Index wird nur rechts unterstützt. Der **Superscript** kann zudem den mathematischen Grad einer Zahl festlegen.

Beispiel:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 

### **Radical‑Methode**
- [Radical(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemstring-method)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemsharedptrimathelement-method)

Definiert die mathematische Wurzel des angegebenen Grades aus dem übergebenen Argument.

Beispiel:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 

### **SetUpperLimit und SetLowerLimit‑Methoden**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemstring-method)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemsharedptrimathelement-method)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemstring-method)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemsharedptrimathelement-method)

Setzt eine obere bzw. untere Grenze. Hier geben obere bzw. untere Grenzen lediglich die Position des Arguments relativ zur Basis an.

Betrachten wir den Ausdruck:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) und [MathLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) sowie Operationen des [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) erzeugt werden:

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 

### **Nary‑ und Integral‑Methoden**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-mathlimitlocations-method)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-mathlimitlocations-method)

Beide Methoden **Nary** und **Integral** erzeugen und geben einen N‑stellig‑Operator zurück, der den Typ [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathnaryoperator/) hat. In **Nary** gibt die Aufzählung [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathnaryoperatortypes/) den Operatortyp an (Summation, Union usw., jedoch nicht Integral). In **Integral** wird die spezialisierte Operation **Integral** mit der Aufzählung [**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathintegraltypes/) verwendet.

Beispiel:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 

### **ToMathArray‑Methode**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tomatharray/) legt Elemente in ein vertikales Array. Wird diese Operation für eine **MathBlock**‑Instanz aufgerufen, werden alle Kindelemente in das zurückgegebene Array abgelegt.

Beispiel:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 

### **Formatierungsoperationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **Accent**‑Methode setzt ein Akzentzeichen (ein Zeichen über dem Element).
- **Overbar**‑ und **Underbar**‑Methoden setzen einen Balken oben bzw. unten.
- **Group**‑Methode platziert das Element in einer Gruppe mittels eines Gruppierungszeichens (z. B. geschweifte Klammer unten oder ein anderes Symbol).
- **ToBorderBox** legt das Element in einen Rand‑Kasten.
- **ToBox** legt das Element in einen nicht‑visuellen Kasten (logische Gruppierung).

Beispiele:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 

## **FAQ**

**Wie kann ich einer PowerPoint‑Folie eine mathematische Gleichung hinzufügen?**

Um eine mathematische Gleichung hinzuzufügen, erstellen Sie ein MathShape‑Objekt, das automatisch einen MathPortion enthält. Anschließend rufen Sie das [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)‑Objekt aus dem [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) ab und fügen dort [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)‑Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erstellen?**

Ja, Aspose.Slides ermöglicht das Erstellen komplexer mathematischer Ausdrücke durch Verschachteln von MathBlocks. Jedes mathematische Element implementiert das [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/)‑Interface, sodass Sie Operationen wie Join, Divide, Enclose usw. anwenden können, um komplexere Strukturen zu bilden.

**Wie kann ich eine vorhandene mathematische Gleichung aktualisieren oder ändern?**

Um eine Gleichung zu aktualisieren, greifen Sie über das [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) auf die bestehenden MathBlocks zu. Durch Methoden wie Join, Divide, Enclose und andere können Sie einzelne Elemente der Gleichung ändern. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen zu übernehmen.