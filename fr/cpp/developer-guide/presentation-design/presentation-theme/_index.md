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
- thème externe
- THMX
- couleur de thème
- palette supplémentaire
- police du thème
- style du thème
- effet du thème
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Thèmes de présentation maîtres dans Aspose.Slides pour C++ afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, de polices, de styles d’arrière‑plan, de remplissages, de lignes et d’effets. Les objets sensibles au thème font référence à ces définitions partagées au lieu de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’une modification de thème peut mettre à jour de nombreux objets en même temps.

Dans Aspose.Slides, le thème au niveau de la présentation est accessible via [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_mastertheme/). Une présentation peut également contenir des remplacements de thème à des niveaux inférieurs. Un maître peut remplacer le thème de la présentation via [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), tandis qu’une disposition ou une diapositive individuelle peut utiliser [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). En pratique, le thème effectif d’une diapositive est résolu à travers cette chaîne d’héritage : thème de la présentation, remplacement du maître, remplacement de la disposition, et remplacement de la diapositive.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Les sections ci‑dessous montrent les flux de travail de thème les plus courants : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effets, et lire les valeurs effectives après résolution de l’héritage et des remplacements.

## **Inspect a Theme**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/mastertheme/) expose les méthodes [get_ColorScheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) et [get_FormatScheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les principales propriétés du thème et indique le nombre de styles d’arrière‑plan, de remplissage, de ligne et d’effet stockés dans le thème :

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

Si un fichier utilise plusieurs maîtres, ne supposez pas que chaque diapositive a le même thème effectif. Inspectez le maître associé à la diapositive, et utilisez le flux de travail « effective‑theme » présenté plus loin dans cet article lorsque des remplacements de disposition ou de diapositive peuvent être présents.

## **Change Theme Colors**

Les remplissages, lignes et textes sensibles au thème peuvent référencer une couleur logique provenant de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [IColorScheme](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/icolorscheme/) du thème, tous les objets qui référencent encore cette couleur de thème sont résolus à la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple complet suivant crée une forme qui utilise `Accent4`, modifie la couleur `Accent4` du thème en rouge, enregistre la présentation, la rouvre et affiche la couleur de remplissage effective :

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

Comme le rectangle reste lié à `Accent4`, sa couleur visible devient rouge après le changement de thème. Si vous remplacez la couleur de schéma par une couleur directe sur la forme, les changements ultérieurs de `Accent4` n’affecteront plus ce remplissage.

### **Use Colors from the Additional Palette**

PowerPoint génère des variantes plus claires et plus foncées à partir d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via [ColorTransformOperation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/colortransformoperation/).

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

Ces variantes restent basées sur la couleur de thème. Si `Accent4` change plus tard, les couleurs transformées sont recalculées à partir de la nouvelle valeur `Accent4`.

### **Map `SchemeColor` Values to `IColorScheme` Slots**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/schemecolor/) utilise `Text1`, `Background1`, `Text2` et `Background2`, tandis que [IColorScheme](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/icolorscheme/) expose les mêmes emplacements de thème sous les noms `Dark1`, `Light1`, `Dark2` et `Light2`. Le mapping est fixe :

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Il s’agit de noms alternatifs pour les mêmes emplacements de thème ; ils ne sont pas des valeurs converties dynamiquement d’une forme à l’autre.

## **Change Theme Fonts**

Un jeu de polices de thème contient un jeu de polices principal pour les titres et un jeu de polices secondaire pour le corps du texte. Les méthodes [FontScheme::get_Major()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/fontscheme/get_major/) et [FontScheme::get_Minor()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/fontscheme/get_minor/) exposent ces jeux.

Les identifiants de police de thème compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn‑lt` - Police du corps Latin (Minor Latin Font)
* `+mj‑lt` - Police du titre Latin (Major Latin Font)
* `+mn‑ea` - Police du corps Asiatique de l’Est (Minor East Asian Font)
* `+mj‑ea` - Police du titre Asiatique de l’Est (Major East Asian Font)

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

Le titre suit la police majeure et le texte du corps suit la police mineure. Le texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le jeu de polices de thème sera modifié.

Les collections de polices majeures et mineures peuvent également contenir des mappages de police pour des systèmes d’écriture individuels, tels que le cyrillique, l’arabe, le japonais, le géorgien et le thaana. Pour inspecter, ajouter, remplacer ou supprimer ces mappages, consultez [Script‑Specific Theme Fonts](/slides/fr/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pour plus d’informations sur les polices de présentation, voir [PowerPoint Fonts](/slides/fr/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Copy or Apply a Theme**

Les flux de travail ci‑dessous résolvent différents problèmes liés aux thèmes.

### **Apply an External Theme to a Master's Dependent Slides**

Utilisez [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) lorsque vous disposez d’un fichier de thème PowerPoint (`.thmx`) et que vous souhaitez re‑styler chaque diapositive dépendant d’un maître particulier. Sélectionnez le maître dans la collection [Presentation::get_Masters](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_masters/), qui implémente [IMasterSlideCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/), puis transmettez le chemin du fichier thème à la méthode.

La méthode exécute les opérations suivantes :

1. Crée une nouvelle diapositive maître basée sur le maître sélectionné.
1. Applique le thème externe au nouveau maître.
1. Associe le nouveau maître à toutes les diapositives qui dépendaient auparavant du maître sélectionné.
1. Retourne le nouvellement créé [IMasterSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/).

L’exemple suivant applique un thème externe aux diapositives dépendant du premier maître et enregistre la présentation :

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

Un thème invalide, corrompu ou non pris en charge peut provoquer [PptxException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pptxexception/) ou l’une de ses sous‑classes liées au format. Validez les chemins fournis par les utilisateurs, gérez les échecs d’accès au système de fichiers et n’enregistrez la présentation qu’après que le thème a été appliqué avec succès.

Seules les diapositives dépendant du maître sélectionné sont réaffectées. Les diapositives associées à d’autres maîtres conservent leurs maîtres et thèmes existants. Les couleurs, polices, remplissages, lignes, arrière‑plans et effets sensibles au thème sont résolus par rapport au thème externe. Les couleurs, polices, remplissages et autres formats attribués directement peuvent rester inchangés. Les remplacements au niveau de la disposition ou de la diapositive peuvent également prévaloir sur les valeurs héritées du nouveau maître.

Le thème peut référencer des polices non disponibles dans l’environnement d’exécution. Pour un rendu et une exportation cohérents, installez les polices requises, fournissez‑les via [custom font sources](/slides/fr/cpp/custom-font/), ou configurez la [font substitution](/slides/fr/cpp/font-substitution/).

Il s’agit d’un flux de travail direct au niveau du maître : la méthode accepte un chemin de fichier `.thmx` et ne nécessite pas de créer manuellement des remplacements de thème au niveau de la diapositive ou de la disposition.

### **Apply Different External Themes in a Multi‑Master Presentation**

Lorsque le maître pertinent n’est pas connu à l’avance, obtenez‑le à partir d’une diapositive représentative via [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islide/get_layoutslide/) et [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ilayoutslide/get_masterslide/). Conservez les références des maîtres originaux avant d’appliquer des thèmes, car chaque appel crée un nouveau maître dans la présentation.

L’exemple suivant utilise des diapositives de deux sections pour localiser leurs maîtres et applique un thème externe différent à chaque groupe :

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

Le premier appel n’affecte que les diapositives dépendant de `firstGroupMaster`, et le second appel n’affecte que celles dépendant de `secondGroupMaster`. Les diapositives appartenant à tout autre maître ne sont pas re‑stylisées.

### **Preserve a Source Theme When Moving Slides**

Si vous devez déplacer une diapositive vers une autre présentation tout en conservant son design d’origine, clonez le maître source dans la présentation cible avec [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/addclone/), puis clonez la diapositive avec [ISlideCollection::AddClone()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/) et le maître cloné. Cela transporte le maître, ses dispositions et le thème associé ensemble.

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

C’est le flux recommandé lorsque la diapositive source doit avoir exactement le même aspect dans la destination. Simplement cloner le contenu sur un maître de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets contrôlés par le thème.

### **Apply Theme Values to an Existing Slide**

Si la diapositive cible doit rester sur son maître et sa disposition actuels, initialisez un remplacement au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) et [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) copient les trois composants principaux du thème dans le remplacement.

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

Cela modifie le thème utilisé par cette diapositive sans toucher au thème hérité par les autres diapositives. Pour supprimer le remplacement local et revenir aux valeurs héritées, appelez [OverrideTheme::Clear()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/overridetheme/clear/).

### **Apply a Theme Override to a Layout**

Un remplacement au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, sauf si une diapositive possède son propre remplacement. Les mêmes méthodes d’initialisation peuvent être utilisées via l’[IOverrideThemeManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ioverridethememanager/) de la disposition :

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

Utilisez un thème au niveau du maître ou de la présentation lorsque de nombreuses dispositions et diapositives doivent partager le même design de base, un remplacement de disposition lorsqu’une famille de dispositions nécessite un style différent, et un remplacement de diapositive uniquement pour de véritables exceptions. Un excès de remplacements au niveau de la diapositive rend les modifications globales de thème ultérieures plus difficiles à prévoir.

## **Update Theme Background Styles**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint peut présenter davantage de choix d’arrière‑plan dans son interface que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’UI peut combiner des remplissages de thème avec des couleurs de thème et d’autres références de style.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée ainsi que l’[Background::get_StyleIndex()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` utilise `0` pour aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan thématisé. Cela diffère de l’indexation directe d’une collection C++ avec `idx_get(0)`, où `0` désigne le premier élément stocké. Ne supposez pas que chaque présentation contient le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, assigne une référence d’arrière‑plan thématisé au premier maître, puis enregistre la présentation :

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

Le résultat visible dépend de l’entrée de thème référencée par le maître et de tout remplacement d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, ne modifier que l’arrière‑plan du maître ne changera pas cette diapositive. Utilisez [Background::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/background/geteffective/) lorsque vous devez connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}
Ne traitez pas `StyleIndex` comme un indice de collection zéro‑based. Évitez également de coder en dur un numéro de style issu d’un fichier et de supposer qu’il aura le même aspect dans un autre fichier ; les définitions de style de thème sont spécifiques à chaque présentation.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pour le formatage direct d’arrière‑plan et l’héritage d’arrière‑plan, consultez [Presentation Background](/slides/fr/cpp/presentation-background/).
{{% /alert %}}

## **Update Theme Effects**

Un schéma de format de thème contient les collections séparées [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/formatscheme/get_linestyles/) et [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Les thèmes Office typiques contiennent souvent trois entrées de style principales correspondant visuellement à un format subtil, modéré et intense, mais le code doit inspecter chaque collection plutôt que de supposer un nombre fixe.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Lorsque vous accédez à ces collections en C++, l’indice de collection commence à zéro : `idx_get(0)` est le premier style stocké et `idx_get(2)` le troisième. Les indices de référence de style d’une forme constituent un concept distinct, exposé via [IShapeStyle](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapestyle/). Modifier un style de thème affecte les formes qui le référencent ; les formes avec un formatage direct peuvent rester inchangées.

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

Pour les formes qui référencent ces emplacements, le premier style de ligne de thème devient rouge, le troisième style de remplissage devient vert forêt plein, et le troisième style d’effet gagne une ombre externe avec une distance de 10 points. Le rendu visuel exact dépend toujours des emplacements de style que chaque forme référence et d’éventuels formatages directs qui surclassent le thème.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Determine Whether an Effective Solid Fill Uses a Theme Color**

Un remplissage peut être stocké directement sur un objet ou hérité d’un paragraphe, d’une disposition, d’un maître, d’un style de thème ou d’un autre niveau de formatage. Appelez [IFillFormat::GetEffective](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifillformat/geteffective/) pour résoudre cette hiérarchie en un objet immuable [IFillFormatEffectiveData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifillformateffectivedata/). Vérifiez d’abord [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Ce n’est que lorsqu’il vaut `FillType::Solid` que vous devez lire les propriétés du remplissage plein.

Pour un remplissage plein, [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) renvoie la valeur RVB finale rendue après héritage, recherche de thème et transformations de couleur. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) renvoie la case logique [SchemeColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/schemecolor/) correspondante, telle que `Text1` ou `Accent6`. Une valeur `SchemeColor::NotDefined` indique que le remplissage plein effectif ne repose pas sur une couleur de schéma. Dans un flux où les remplissages sont soit des couleurs de thème, soit des couleurs RVB directes, cette valeur identifie un remplissage RVB direct.

N’utilisez pas uniquement la valeur locale [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icolorformat/get_schemecolor/) pour classer un remplissage. Par exemple, une portion de texte peut ne pas définir de couleur de schéma localement, donc sa valeur locale est `NotDefined`, tandis que son remplissage effectif hérite d’une couleur de thème et se résout en `Text1` ou `Accent6`. Inversement, `get_SolidFillSchemeColor` indique quelle case logique de thème a produit la couleur effective, mais ne précise pas si cette case provient de l’objet, du paragraphe, de la disposition, du maître ou d’un autre niveau de la hiérarchie de formatage.

L’exemple suivant charge une présentation, examine les remplissages des formes et des portions de texte, affiche chaque valeur RVB finale et la couleur de schéma associée, et signale les remplissages pleins qui ne suivront pas les changements de couleur de thème :

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

La branche `NotDefined` fournit une liste d’audit des remplissages pleins qui ne réagiront pas aux changements des cases de couleur de thème. Examinez ces objets lorsqu’une présentation doit suivre une nouvelle palette de marque. La valeur RVB affichée montre encore l’apparence actuelle, tandis que la valeur de schéma explique si cette apparence est liée au thème.

Les objets de format effectif sont des instantanés. Après avoir modifié le thème de la présentation, un remplacement de thème ou tout formatage hérité, appelez à nouveau `GetEffective` et lisez un nouvel objet `IFillFormatEffectiveData` avant de comparer ou de rapporter les couleurs.

## **Read Effective Theme Values**

Les objets de thème bruts indiquent ce qui est défini à un niveau particulier. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution de l’héritage et des remplacements locaux. Pour une diapositive, appelez [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Pour un arrière‑plan, utilisez [Background::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/background/geteffective/), et pour un remplissage, utilisez [FillFormat::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fillformat/geteffective/).

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

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous n’inspectez que [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_mastertheme/), vous risquez de manquer un remplacement au niveau du maître, de la disposition, de la diapositive ou de la forme qui modifie l’apparence finale.

## **FAQ**

**Applying an external theme affect every slide in the presentation?**

Non. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) ne réaffecte que les diapositives dépendant du maître sélectionné. Les diapositives utilisant d’autres maîtres conservent leurs thèmes existants.

**Can I apply a theme to a single slide without changing the master?**

Oui. Utilisez l’[IOverrideThemeManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ioverridethememanager/) de la diapositive et initialisez son thème de remplacement. Le changement reste local à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes existants.

**What is the safest way to carry a theme from one presentation to another?**

Lorsque vous déplacez une diapositive tout en préservant son apparence source, clonez le maître source dans la destination et clonez la diapositive avec ce maître en utilisant [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imasterslidecollection/addclone/) et [ISlideCollection::AddClone()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidecollection/addclone/). Cela conserve le maître, les dispositions et le thème ensemble.

**How can I see the effective values after inheritance and overrides?**

Utilisez [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) pour un thème de diapositive ou de disposition et les méthodes de données effectives correspondantes pour les objets de format tels que [Background::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/background/geteffective/) et [FillFormat::GetEffective()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fillformat/geteffective/). Ces API renvoient les valeurs résolues après application de l’héritage et des remplacements.