---
title: Gérer les thèmes de présentation en C++
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/cpp/presentation-theme/
keywords:
- thème PowerPoint
- thème de présentation
- thème de diapositive
- définir le thème
- modifier le thème
- gérer le thème
- couleur du thème
- palette supplémentaire
- police du thème
- style du thème
- effet du thème
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Maîtrisez les thèmes de présentation dans Aspose.Slides pour C++ afin de créer, personnaliser et convertir des fichiers PowerPoint avec une image de marque cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, de polices, de styles d’arrière‑plan, de remplissages, de lignes et d’effets. Les objets sensibles au thème font référence à ces définitions partagées plutôt que de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’une modification du thème peut mettre à jour de nombreux objets en même temps.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_mastertheme/). Une présentation peut également contenir des surcharges de thème à des niveaux inférieurs. Un master peut remplacer le thème de la présentation via [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), tandis qu’une disposition ou une diapositive individuelle peut utiliser [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). En pratique, le thème effectif d’une diapositive est résolu à travers cette chaîne d’héritage : thème de la présentation, surcharge du master, surcharge de la disposition et surcharge de la diapositive.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Les sections ci‑dessous montrent les flux de travail les plus courants liés aux thèmes : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effets, et lire les valeurs effectives après résolution des héritages et des surcharges.

## **Inspecter un thème**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/mastertheme/) expose les méthodes du thème : [get_ColorScheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) et [get_FormatScheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les principales propriétés du thème et indique combien de styles d’arrière‑plan, de remplissage, de ligne et d’effet sont stockés dans le thème :

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Si un fichier utilise plusieurs masters, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le master associé à la diapositive, et utilisez le flux de travail « thème effectif » présenté plus loin dans cet article lorsqu’une surcharge de disposition ou de diapositive peut être présente.

## **Modifier les couleurs du thème**

Les remplissages, lignes et textes sensibles au thème peuvent faire référence à une couleur logique provenant de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [IColorScheme](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/icolorscheme/) du thème, tous les objets qui font encore référence à cette couleur de thème sont résolus avec la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple complet suivant crée une forme qui utilise `Accent4`, change la couleur `Accent4` du thème en rouge, enregistre la présentation, la rouvre et affiche la couleur de remplissage effective :

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après la modification du thème. Si vous remplacez la couleur de schéma par une couleur directe sur la forme, les changements ultérieurs de `Accent4` n’affecteront plus ce remplissage.

### **Utiliser les couleurs de la palette supplémentaire**

PowerPoint dérive des variantes plus claires et plus foncées d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via [ColorTransformOperation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Couleurs principales du thème.

**2** - Variantes plus claires et plus foncées générées à partir des couleurs principales du thème.

L’exemple suivant crée six rectangles basés sur `Accent4`, applique des transformations de luminance à cinq d’entre eux, puis enregistre le résultat :

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Ces variantes restent basées sur la couleur de thème. Si `Accent4` change ultérieurement, les couleurs transformées sont recalculées à partir de la nouvelle valeur `Accent4`.

### **Mapper les valeurs `SchemeColor` aux emplacements `IColorScheme`**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que [IColorScheme](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/icolorscheme/) expose les mêmes emplacements de thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mappage est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Il s’agit de noms alternatifs pour les mêmes emplacements de thème ; il ne s’agit pas de valeurs converties dynamiquement d’une forme à l’autre.

## **Modifier les polices du thème**

Un schéma de polices de thème contient un ensemble de polices principales pour les titres et un ensemble de polices secondaires pour le texte du corps. Les méthodes [FontScheme::get_Major()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/fontscheme/get_major/) et [FontScheme::get_Minor()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/fontscheme/get_minor/) exposent ces ensembles.

Les identifiants de police de thème compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn-lt` - Police du corps Latin (Minor Latin Font)
* `+mj-lt` - Police du titre Latin (Major Latin Font)
* `+mn-ea` - Police du corps Asie de l’Est (Minor East Asian Font)
* `+mj-ea` - Police du titre Asie de l’Est (Major East Asian Font)

L’exemple suivant crée un titre qui utilise la police Latin principale du thème et une ligne de corps qui utilise la police Latin secondaire du thème. Il modifie ensuite les polices du thème et enregistre le résultat :

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

Le titre suit la police principale et le texte du corps suit la police secondaire. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le schéma de polices du thème est modifié.

Les collections majeures et mineures peuvent également contenir des correspondances de police pour des systèmes d’écriture individuels, tels que cyrillique, arabe, japonais, géorgien et thaana. Pour inspecter, ajouter, remplacer ou supprimer ces correspondances, consultez [Script-Specific Theme Fonts](/slides/fr/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pour plus d’informations sur les polices de présentation, voir [PowerPoint Fonts](/slides/fr/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Copier ou appliquer un thème**

Il existe deux flux de travail courants, qui résolvent des problèmes différents.

### **Conserver le thème source lors du déplacement de diapositives**

Si vous souhaitez déplacer une diapositive vers une autre présentation tout en conservant son design d’origine, clonez le master source dans la présentation cible avec [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/addclone/), puis clonez la diapositive avec [ISlideCollection::AddClone()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) et le master cloné. Cela transporte le master, ses dispositions et le thème associé en même temps.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

C’est le flux de travail préféré lorsque la diapositive source doit conserver exactement le même aspect dans la destination. Simplement cloner le contenu sur un master de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets pilotés par le thème.

### **Appliquer des valeurs de thème à une diapositive existante**

Si la diapositive cible doit rester sur son master et sa disposition actuels, initialisez une surcharge au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) et [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) copient les trois principaux composants du thème dans la surcharge.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

Cela modifie le thème utilisé par cette diapositive sans modifier le thème hérité par les autres diapositives. Pour supprimer la surcharge locale et revenir aux valeurs héritées, appelez [OverrideTheme::Clear()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/overridetheme/clear/).

### **Appliquer une surcharge de thème à une disposition**

Une surcharge au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, à moins qu’une diapositive particulière n’ait sa propre surcharge. Les mêmes méthodes d’initialisation peuvent être utilisées via le [IOverrideThemeManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ioverridethememanager/) de la disposition :

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Utilisez un thème au niveau du master ou de la présentation lorsque de nombreuses dispositions et diapositives doivent partager le même design de base, une surcharge de disposition lorsqu’une famille de dispositions nécessite un style différent, et une surcharge de diapositive uniquement pour de véritables exceptions. Un excès de surcharges au niveau de la diapositive rend les changements globaux de thème ultérieurs plus difficiles à prévoir.

## **Mettre à jour les styles d’arrière‑plan du thème**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint peut afficher davantage de choix d’arrière‑plan dans son interface utilisateur que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’UI peut combiner des remplissages de thème avec des couleurs de thème et d’autres références de style.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et la valeur actuelle de [Background::get_StyleIndex()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` utilise `0` pour aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan thématisé. Ceci diffère de l’indexation d’une collection C++ directement avec `idx_get(0)`, où `0` désigne le premier élément stocké. Ne supposez pas que chaque présentation contienne le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, attribue une référence d’arrière‑plan thématisé au premier master, puis enregistre la présentation :

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

Le résultat visible dépend de l’entrée de thème référencée par le master et de toute surcharge d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, modifier uniquement l’arrière‑plan du master peut ne pas affecter cette diapositive. Utilisez [Background::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/background/geteffective/) lorsque vous devez connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}
Ne traitez pas `StyleIndex` comme un indice de collection basé sur zéro. Évitez également de coder en dur un numéro de style provenant d’un fichier et de supposer qu’il aura le même aspect dans un autre fichier ; les définitions de style de thème sont spécifiques à chaque présentation.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pour le formatage direct d’arrière‑plan et l’héritage d’arrière‑plan, consultez [Presentation Background](/slides/fr/cpp/presentation-background/).
{{% /alert %}}

## **Mettre à jour les effets du thème**

Un schéma de format de thème contient des collections distinctes : [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/formatscheme/get_linestyles/) et [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Les thèmes Office typiques contiennent souvent trois entrées de style principales qui correspondent visuellement à des formats subtils, modérés et intenses, mais le code doit inspecter chaque collection au lieu de supposer un nombre fixe.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Lorsque vous accédez à ces collections en C++, l’indice de collection est basé sur zéro : `idx_get(0)` est le premier style stocké et `idx_get(2)` le troisième. Les indices de référence de style d’une forme constituent un concept séparé, exposé via [IShapeStyle](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapestyle/). Modifier un style de thème affecte les formes qui font référence à ce style ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, modifie le troisième style de remplissage, active une ombre externe dans le troisième style d’effet, puis enregistre le résultat :

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Pour les formes qui font référence à ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt solide, et le troisième style d’effet gagne une ombre externe avec une distance de 10 points. Le rendu visuel exact dépend toujours des emplacements de style référencés par chaque forme et d’éventuels formatages directs qui remplacent le thème.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Lire les valeurs effectives du thème**

Les objets de thème bruts indiquent ce qui est défini à un niveau particulier. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution des héritages et des surcharges locales. Pour une diapositive, appelez [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Pour un arrière‑plan, utilisez [Background::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/background/geteffective/), et pour un remplissage, utilisez [FillFormat::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fillformat/geteffective/).

L’exemple suivant lit le thème effectif, l’arrière‑plan et le premier remplissage de forme d’une diapositive :

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_mastertheme/), vous pouvez manquer une surcharge de master, de disposition, de diapositive ou de forme qui modifie l’apparence finale.

## **FAQ**

**Puis‑je appliquer un thème à une seule diapositive sans changer le master ?**

Oui. Utilisez le [IOverrideThemeManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ioverridethememanager/) de la diapositive et initialisez son thème de surcharge. La modification reste locale à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes actuels.

**Quelle est la méthode la plus sûre pour transférer un thème d’une présentation à une autre ?**

Lors du déplacement d’une diapositive tout en conservant son apparence source, clonez le master source dans la destination et clonez la diapositive avec ce master à l’aide de [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/addclone/) et [ISlideCollection::AddClone()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/). Cela garde le master, les dispositions et le thème ensemble.

**Comment puis‑je voir les valeurs effectives après héritage et surcharges ?**

Utilisez [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) pour un thème de diapositive ou de disposition et les méthodes de données effectives correspondantes pour les objets de format tels que [Background::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/background/geteffective/) et [FillFormat::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fillformat/geteffective/). Ces API renvoient les valeurs résolues après application des héritages et des surcharges.