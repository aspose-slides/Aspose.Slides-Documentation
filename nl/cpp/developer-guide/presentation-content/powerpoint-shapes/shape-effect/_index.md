---
title: Vormeffecten toepassen in presentaties met C++
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/cpp/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie-effect
- gloeieffect
- zachte randen-effect
- effectformaat
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Transformeer uw PPT- en PPTX-bestanden met geavanceerde vormeffecten via Aspose.Slides voor C++ — maak in enkele seconden opvallende, professionele dia's."
---
## **Inleiding**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [opvullingen](/slides/nl/cpp/shape-formatting/#gradient-fill) of randen. Met PowerPoint-effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

![Shape effect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meer effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Daarom heeft PowerPoint opties onder **Voorinstelling**. De Voorinstelling‑opties zijn in wezen een combinatie die bekend staat als goed uitziend van twee of meer effecten. Op deze manier hoef je bij het selecteren van een voorinstelling geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) klasse die je toelaten dezelfde effecten toe te passen op vormen in PowerPoint‑presentaties.

## **Een schaduweffect toepassen**

Aspose.Slides voor C++ ondersteunt buiten- en binnenschaduwen voor vormen. Je kunt hun kleur, richting, afstand en vervagingsradius aanpassen zodat ze passen bij het ontwerp van je presentatie.

### **Een buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de achtergrond van de dia. De schaduw strekt zich uit voorbij de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de dia zweeft. Pas de kleur, richting, afstand en vervagingsradius aan zodat ze overeenkomen met de verlichting en stijl van je sjabloon.

Deze C++‑code laat zien hoe je het [buitenste schaduweffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) op een rechthoek toepast:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![Shadow effect](shadow_effect.png)

### **Een binnenschaduw toepassen**

Wanneer je de visuele styling van een sjabloon nabootst, gebruik je een binnenschaduw om een kaart of paneel een ingesprongen uiterlijk te geven. Een buitenste schaduw strekt zich uit buiten de vorm en laat deze verhoogd lijken, terwijl een binnenschaduw de binnenkant van de randen kleurt.

Roep [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) aan en configureer vervolgens [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Grotere waarden voor de vervagingsradius geven zachtere randen.

Dit C++‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenschaduw en slaat deze op als een PPTX‑bestand:

```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![Lichtblauwe rechthoek met een binnenschaduw](inner_shadow_effect.png)

Om de binnenschaduw te verwijderen, roep je [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) aan op het effectformaat van de vorm.

## **Een reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor C++, kun je een spiegelachtige reflectie aan vormen toevoegen, waarbij je parameters zoals afstand, transparantie en grootte aanpast. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met eenvoudige code, waardoor je het snel kunt toepassen op meerdere elementen voor een consistent ontwerp.

Deze C++‑code laat zien hoe je het [reflectie‑effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) op een vorm toepast:

```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![Reflectie‑effect](reflection_effect.png)

## **Een gloeieffect toepassen**

Om een gloeieffect op een vorm toe te passen in Aspose.Slides voor C++, kun je een zachte, lichtgevende aura rond vormen toevoegen, waarbij je eigenschappen zoals kleur en grootte aanpast. Dit effect helpt vormen te laten opvallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het algehele uiterlijk van je dia's wordt verbeterd.

Deze C++‑code laat zien hoe je het [gloeieffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) op een vorm toepast:

```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![Gloeieffect](glow_effect.png)

## **Een zacht rand‑effect toepassen**

Om een zacht‑rand‑effect toe te passen in Aspose.Slides voor C++, kun je een vloeiende, vervaagde overgang rond de randen van een vorm creëren. Dit effect geeft een subtieler en verfijnder uiterlijk, perfect voor ontwerpen die een zachte, zachtere uitstraling nodig hebben. Je kunt eenvoudig parameters zoals radius aanpassen om het gewenste effect te bereiken voor verschillende vormen in je presentatie.

Deze C++‑code laat zien hoe je de [zachte randen](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) op een vorm toepast:

```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![Zachte randen](soft_edges_effect.png)

## **Veelgestelde vragen**

**Kan ik meerdere effecten toepassen op dezelfde vorm?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één vorm om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder AutoShapes, grafieken, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt toegepast op de gehele groep.