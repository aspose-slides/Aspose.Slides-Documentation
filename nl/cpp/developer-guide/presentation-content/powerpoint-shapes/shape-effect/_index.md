---
title: Vormeffecten toepassen in presentaties met C++
linktitle: Vorm effect
type: docs
weight: 30
url: /nl/cpp/shape-effect/
keywords:
- vorm effect
- schaduw effect
- reflectie effect
- gloei effect
- zachte randen effect
- effectformaat
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Transformeer je PPT- en PPTX-bestanden met geavanceerde vormeffecten met behulp van Aspose.Slides voor C++ — maak verbluffende, professionele dia's in enkele seconden."
---
## **Introductie**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/cpp/shape-formatting/#gradient-fill) of contouren. Met PowerPoint-effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

![Vorm effect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meer effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Daarom heeft PowerPoint opties onder **Voorinstelling**. De voorinstellingsopties zijn in wezen een combinatie van twee of meer effecten die goed samen passen. Op deze manier hoef je, door een voorinstelling te kiezen, geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) klasse die je in staat stellen dezelfde effecten toe te passen op vormen in PowerPoint‑presentaties.

## **Schaduweffect toepassen**

Aspose.Slides voor C++ ondersteunt buiten‑ en binnenschaduwen voor vormen. Je kunt hun kleur, richting, afstand en vervagingsstraal aanpassen aan het ontwerp van je presentatie.

### **Buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de slide‑achtergrond. De schaduw strekt zich uit buiten de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de slide zweeft. Pas de kleur, richting, afstand en vervagingsstraal aan om overeen te komen met de belichting en stijl van je sjabloon.

Deze C++‑code laat zien hoe je het [buitenste schaduw effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) toepast op een rechthoek:

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

![Schaduw effect](shadow_effect.png)

### **Binnenste schaduw toepassen**

Bij het nabootsen van de visuele stijl van een sjabloon, gebruik een binnenschaduw om een kaart of paneel een ingetogen uiterlijk te geven. Een buitenste schaduw strekt zich buiten de vorm uit en laat deze omhoog lijken, terwijl een binnenschaduw de binnenkant van de randen schaduwt.

Roep [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) aan en configureer vervolgens [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Grotere vervagingsstraalwaarden geven zachtere randen.

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

## **Reflectie effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor C++, kun je een spiegelachtige reflectie aan vormen toevoegen en parameters zoals afstand, transparantie en grootte aanpassen. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met simpele code, waardoor snelle toepassing over meerdere elementen mogelijk is voor een consistent ontwerp.

Deze C++‑code laat zien hoe je het [reflectie effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) toepast op een vorm:

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

## **Gloei‑effect toepassen**

Om een gloei‑effect toe te voegen aan een vorm in Aspose.Slides voor C++, kun je een zachte, lichtgevende aura rondom vormen plaatsen en eigenschappen zoals kleur en grootte aanpassen. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het algehele uiterlijk van je dia’s wordt verbeterd.

Deze C++‑code laat zien hoe je het [gloei‑effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) toepast op een vorm:

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

![Gloei‑effect](glow_effect.png)

## **Zachte randen‑effect toepassen**

Om een zachte randen‑effect toe te passen in Aspose.Slides voor C++, kun je een soepele, vervaagde overgang rond de randen van een vorm creëren. Dit effect voegt een subtieler en verfijnder uiterlijk toe, perfect voor ontwerpen die een zachte, subtiele uitstraling nodig hebben. Je kunt eenvoudig parameters zoals straal aanpassen om het gewenste effect te bereiken op verschillende vormen in je presentatie.

Deze C++‑code laat zien hoe je het [zachte randen](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) toepast op een vorm:

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

![Zachte randen‑effect](soft_edges_effect.png)

## **Vervaag‑effect toepassen**

Gebruik vormvervaging om de vulling en contour van een vorm zachter te maken terwijl de vorm bewerkbaar blijft. Roep [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) aan op het effectformaat van de vorm. De straal wordt gemeten in punten (1/72 inch): gebruik een niet‑negatieve waarde, waarbij grotere waarden een sterkere vervaging geven. Een straal van nul laat het uiterlijk ongewijzigd.

De [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) instelling bepaalt de zichtbare grenzen van het effect. Met `false` wordt de vervaging begrensd tot de oorspronkelijke geschilderde grenzen, inclusief de contour. Met `true` kan de vervaging buiten die grenzen uitbreiden. Geen van beide instellingen verandert de positie of afmetingen van de vorm.

De onderstaande vergelijking gebruikt dezelfde vulling, contour en vormafmetingen overal. De bovenste rij gebruikt `grow = false`; de onderste rij gebruikt `grow = true`.

![Originele rechthoek vergeleken met vervagingsstraal van 5 en 15 punten, met grow uitgeschakeld en ingeschakeld](shape_blur_comparison.png)

Dit C++‑voorbeeld maakt een oranje rechthoek met een donkerblauwe contour, past een vervaging van 5 punten toe en werkt deze vervolgens bij naar een vervaging van 15 punten door opnieuw [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) aan te roepen. Het slaat beide vervaagde toestanden op, roept vervolgens [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) aan en slaat de vorm zonder vervaging op.

```cpp
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

Vormvervaging beïnvloedt zowel de vulling als de contour tegelijk. Een zachte randen‑effect vervaagt de randen van de vorm, terwijl schaduwvervaging alleen de schaduw verzacht. Beeldtransformatieteffecten werken op de beeldinhoud; dit voorbeeld past vervaging direct toe op het effectformaat van de vorm zonder de vorm naar een afbeelding te converteren.

## **Veelgestelde vragen**

**Kan ik meerdere effecten toepassen op dezelfde vorm?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één vorm om een dynamischer uiterlijk te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder auto‑shapes, grafieken, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt toegepast op de hele groep.