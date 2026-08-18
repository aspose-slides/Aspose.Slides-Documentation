---
title: Gérer les thèmes de présentation en C++
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/cpp/presentation-theme/
keywords:
- Thème PowerPoint
- Thème de présentation
- Thème de diapositive
- Définir le thème
- Modifier le thème
- Gérer le thème
- Couleur du thème
- Palette supplémentaire
- Police du thème
- Style du thème
- Effet du thème
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Maîtrisez les thèmes de présentation dans Aspose.Slides pour C++ afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, de polices, de styles d’arrière‑plan, de remplissages, de lignes et d’effets. Les objets sensibles au thème se réfèrent à ces définitions partagées au lieu d’enregistrer chaque propriété visuelle comme une valeur fixe, de sorte qu’un changement de thème peut mettre à jour de nombreux objets à la fois.

Dans Aspose.Slides, le thème au niveau de la présentation est accessible via [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_mastertheme/). Une présentation peut également contenir des substituts de thème à des niveaux inférieurs. Un maître peut remplacer le thème de la présentation via [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), tandis qu’une disposition ou une diapositive individuelle peut utiliser [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). En pratique, le thème effectif d’une diapositive est résolu à travers cette chaîne d’héritage : thème de la présentation, remplacement du maître, remplacement de la disposition et remplacement de la diapositive.

![Composants du thème : couleurs, polices, styles d’arrière‑plan et effets](theme-constituents.png)

Les sections ci‑dessous présentent les flux de travail les plus courants : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effets, et lire les valeurs effectives après résolution des héritages et des remplacements.

## **Inspecter un thème**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/mastertheme/) expose les méthodes du thème : [get_ColorScheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) et [get_FormatScheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les propriétés principales du thème et indique combien de styles d’arrière‑plan, de remplissage, de ligne et d’effet sont stockés dans le thème :

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

Si un fichier utilise plusieurs maîtres, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le maître associé à la diapositive, et utilisez le flux de travail du thème effectif présenté plus loin dans cet article lorsqu’un remplacement de disposition ou de diapositive peut être présent.

## **Modifier les couleurs du thème**

Les remplissages, lignes et textes sensibles au thème peuvent faire référence à une couleur logique provenant de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [IColorScheme](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/icolorscheme/) du thème, tous les objets qui font encore référence à cette couleur de thème sont résolus avec la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple de bout en bout suivant crée une forme qui utilise `Accent4`, change la couleur `Accent4` du thème en rouge, enregistre la présentation, la rouvre et affiche la couleur de remplissage effective :

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

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après la modification du thème. Si vous remplacez la couleur de schéma par une couleur directe sur la forme, les modifications ultérieures de `Accent4` n’affecteront plus ce remplissage.

### **Utiliser les couleurs de la palette supplémentaire**

PowerPoint dérive des variantes plus claires et plus foncées d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via [ColorTransformOperation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/colortransformoperation/).

![Couleurs principales du thème et couleurs plus claires et plus foncées générées à partir de la palette supplémentaire](additional-palette-colors.png)

**1** - Couleurs principales du thème.  
**2** - Variantes plus claires et plus foncées produites à partir des couleurs principales du thème.

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

Ces variantes restent fondées sur la couleur du thème. Si `Accent4` change plus tard, les couleurs transformées sont recalculées à partir de la nouvelle valeur `Accent4`.

### **Faire correspondre les valeurs `SchemeColor` aux emplacements `IColorScheme`**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que [IColorScheme](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/icolorscheme/) expose les mêmes emplacements du thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mappage est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ce sont des noms alternatifs pour les mêmes emplacements du thème ; il ne s’agit pas de valeurs converties dynamiquement d’une forme à une autre.

## **Modifier les polices du thème**

Un jeu de polices du thème contient un jeu de polices principal pour les titres et un jeu de polices secondaire pour le texte du corps. Les méthodes [FontScheme::get_Major()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/fontscheme/get_major/) et [FontScheme::get_Minor()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/fontscheme/get_minor/) exposent ces ensembles.

Les identifiants de police compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn‑lt` - Police du corps Latin (Minor Latin Font)
* `+mj‑lt` - Police du titre Latin (Major Latin Font)
* `+mn‑ea` - Police du corps Asie de l’Est (Minor East Asian Font)
* `+mj‑ea` - Police du titre Asie de l’Est (Major East Asian Font)

L’exemple suivant crée un titre qui utilise la police majeure Latin du thème et une ligne de corps qui utilise la police mineure Latin du thème. Il modifie ensuite les polices du thème et enregistre le résultat :

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

Le titre suit la police majeure et le texte du corps suit la police mineure. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le jeu de polices du thème évoluera.

{{% alert color="info" title="Tip" %}}
Pour plus d’informations sur les polices de présentation, consultez [PowerPoint Fonts](/slides/fr/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Copier ou appliquer un thème**

Il existe deux flux de travail courants, qui résolvent des problèmes différents.

### **Conserver un thème source lors du déplacement de diapositives**

Si vous souhaitez déplacer une diapositive vers une autre présentation tout en conservant son design original, clonez le maître source dans la présentation cible avec [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/addclone/), puis clonez la diapositive avec [ISlideCollection::AddClone()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) et le maître cloné. Cela transporte le maître, ses dispositions et le thème associé ensemble.

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

C’est le flux de travail recommandé lorsque la diapositive source doit rester identique dans la destination. Cloner simplement le contenu sur un maître de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets pilotés par le thème.

### **Appliquer les valeurs du thème à une diapositive existante**

Si la diapositive cible doit rester sur son maître et sa disposition actuels, initialisez un remplacement au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) et [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) copient les trois principales composantes du thème dans le remplacement.

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

Cela modifie le thème utilisé par cette diapositive sans changer le thème hérité par les autres diapositives. Pour supprimer le remplacement local et revenir aux valeurs héritées, appelez [OverrideTheme::Clear()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/overridetheme/clear/).

### **Appliquer un remplacement de thème à une disposition**

Un remplacement au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, sauf si une diapositive particulière possède son propre remplacement. Les mêmes méthodes d’initialisation peuvent être utilisées via le [IOverrideThemeManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ioverridethememanager/) de la disposition :

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

Utilisez un thème au niveau du maître ou de la présentation lorsque de nombreuses dispositions et diapositives doivent partager le même design de base, un remplacement de disposition lorsqu’une famille de dispositions nécessite un style différent, et un remplacement de diapositive uniquement pour les véritables exceptions. Un excès de remplacements au niveau des diapositives complique la prévision des changements globaux de thème.

## **Mettre à jour les styles d’arrière‑plan du thème**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint peut présenter plus de choix d’arrière‑plan dans son interface que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’UI peut combiner les remplissages de thème avec les couleurs de thème et d’autres références de style.

![Galerie de styles d’arrière‑plan PowerPoint pour un thème de présentation](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et l’indice actuel via [Background::get_StyleIndex()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` utilise `0` pour aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan du thème. Cela diffère de l’indexation directe d’une collection C++ avec `idx_get(0)`, où `0` correspond au premier élément stocké. Ne supposez pas que chaque présentation contient le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, affecte une référence d’arrière‑plan thématisé au premier maître, puis enregistre la présentation :

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

Le résultat visible dépend de l’entrée du thème référencée par le maître et de tout remplacement d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, modifier uniquement l’arrière‑plan du maître peut ne pas affecter cette diapositive. Utilisez [Background::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/background/geteffective/) lorsque vous devez connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}
Ne traitez pas `StyleIndex` comme un indice de collection à base zéro. Évitez également de coder en dur un numéro de style d’un fichier et de supposer qu’il donne le même rendu dans un autre fichier ; les définitions de style du thème sont propres à chaque présentation.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pour le formatage direct d’arrière‑plan et l’héritage d’arrière‑plan, consultez [Presentation Background](/slides/fr/cpp/presentation-background/).
{{% /alert %}}

## **Mettre à jour les effets du thème**

Un schéma de format du thème contient des collections distinctes : [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/formatscheme/get_linestyles/) et [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Les thèmes Office typiques contiennent souvent trois entrées de style principales correspondant visuellement à des formats subtils, modérés et intenses, mais le code doit inspecter chaque collection plutôt que de supposer un nombre fixe.

![Effets de thème subtils, modérés et intenses appliqués à la même forme](presentation-design_10.png)

Lorsque vous accédez à ces collections en C++, l’indice de la collection est basé sur zéro : `idx_get(0)` renvoie le premier style stocké et `idx_get(2)` le troisième. Les indices de référence de style d’une forme constituent un concept séparé, exposé via [IShapeStyle](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapestyle/). Modifier un style de thème affecte les formes qui font référence à ce style ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, change le troisième style de remplissage, active une ombre extérieure dans le troisième style d’effet, puis enregistre le résultat :

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

Pour les formes qui référencent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt plein, et le troisième style d’effet gagne une ombre extérieure avec une distance de 10 points. Le résultat visuel exact dépend encore de quels emplacements chaque forme référence et si un formatage direct surcharge le thème.

![Styles d’effet du thème après modification des paramètres de ligne, de remplissage et d’ombre](presentation-design_11.png)

## **Lire les valeurs effectives du thème**

Les objets de thème bruts indiquent ce qui est défini à un niveau donné. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution des héritages et des remplacements locaux. Pour une diapositive, appelez [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Pour un arrière‑plan, utilisez [Background::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/background/geteffective/), et pour un remplissage, utilisez [FillFormat::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fillformat/geteffective/).

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

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_mastertheme/), vous pouvez manquer un remplacement de maître, de disposition, de diapositive ou de forme qui modifie l’apparence finale.

## **FAQ**

**Puis‑je appliquer un thème à une seule diapositive sans modifier le maître ?**

Oui. Utilisez le [IOverrideThemeManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ioverridethememanager/) de la diapositive et initialisez son thème de remplacement. La modification reste locale à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes existants.

**Quelle est la manière la plus sûre de transférer un thème d’une présentation à une autre ?**

Lors du déplacement d’une diapositive tout en conservant son apparence source, clonez le maître source dans la destination et clonez la diapositive avec ce maître à l’aide de [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/addclone/) et de [ISlideCollection::AddClone()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/). Cela garde le maître, les dispositions et le thème ensemble.

**Comment puis‑je voir les valeurs effectives après héritage et remplacements ?**

Utilisez [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) pour un thème de diapositive ou de disposition et les méthodes de données effectives correspondantes pour les objets de format tels que [Background::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/background/geteffective/) et [FillFormat::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fillformat/geteffective/). Ces API renvoient les valeurs résolues après application de l’héritage et des remplacements.