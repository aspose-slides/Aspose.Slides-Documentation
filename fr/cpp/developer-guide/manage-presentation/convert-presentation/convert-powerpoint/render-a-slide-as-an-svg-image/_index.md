---
title: Rendre les diapositives de présentation en images SVG en C++
linktitle: Diapositive vers SVG
type: docs
weight: 50
url: /fr/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint vers SVG
- présentation vers SVG
- diapositive vers SVG
- PPT vers SVG
- PPTX vers SVG
- "options d'exportation SVG"
- SVG interactif
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Exportez les diapositives PowerPoint en images SVG en C++ et contrôlez les polices, le texte, les images, les ID et les événements avec Aspose.Slides."
---
## **Vue d'ensemble**

SVG est un format d'image XML évolutif qui fonctionne bien pour la publication Web, les visionneuses de diapos, les flux de travail d'accessibilité et le post‑traitement automatisé. Aspose.Slides for C++ exporte chaque diapositive vers un fichier SVG distinct et vous permet de contrôler la façon dont le texte, les polices, les images et les éléments SVG sont écrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) lorsque le SVG exporté doit être compact, prévisible sur tous les navigateurs ou prêt à être utilisé de manière interactive.

## **Exporter une diapositive au format SVG**

Créez une [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), sélectionnez une diapositive et écrivez‑la dans un flux. L'exemple suivant exporte chaque diapositive d'une présentation vers un fichier SVG distinct.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

Le nom de fichier utilise [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) plutôt que l'index de boucle. Vous pouvez également exporter une forme individuelle avec [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) lorsqu'un visionneur de diapos ou une page Web ne nécessite que cette forme.

## **Configurer la sortie SVG**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) contrôle le rendu SVG. Pour les cadres de texte, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) inclut le cadre de texte dans la zone de rendu, et [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) détermine si la rotation du cadre est appliquée. Définissez [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) sur `true` lorsque le texte doit être rendu sans ligatures.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Contrôler le texte et les polices**

Lors de l'exportation de diapositives au format SVG, vous pouvez contrôler si le texte reste du texte ou est converti en graphiques vectoriels, ainsi que la façon dont les polices externes sont incluses ou référencées. Les options suivantes vous aident à équilibrer la cohérence visuelle, la sélection du texte et les dépendances de polices dans le SVG exporté.

### **Vectoriser tout le texte**

Définissez [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) sur `true` pour écrire tout le texte de la diapositive sous forme de graphiques vectoriels. Cela élimine les dépendances aux polices et rend le résultat visuel plus cohérent entre les navigateurs, mais le texte n'est plus sélectionnable ou recherchable en tant que texte SVG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **Choisir la façon dont les polices externes sont gérées**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) pour les polices chargées de manière externe. Choisissez `AddLinksToFontFiles` pour référencer des fichiers de police séparés, `Embed` pour inclure les données de police dans le SVG, ou `Vectorize` pour rendre uniquement le texte qui utilise des polices externes sous forme de graphiques. Vérifiez les licences des polices avant d'intégrer les polices.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **Réduire la taille des images intégrées**

Utilisez [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) pour réduire la résolution des images intégrées, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) pour omettre les zones source recadrées, et [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) pour contrôler la qualité d'encodage JPEG. Ces paramètres réduisent la taille du fichier au détriment de la fidélité de l'image ou des données d'image conservées.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Contrôler la résolution de rasterisation des métafichiers**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) définit la limite inférieure de résolution pour la rasterisation des métas fichiers lors de l'exportation SVG. Utilisez‑le pour équilibrer le détail et la taille du fichier lorsqu'une image EMF ou WMF est rasterisée. Il ne définit pas un DPI global pour le SVG ni ne force chaque objet de la diapositive à devenir une image raster.

Téléchargez [metafile-rasterization.pptx](metafile-rasterization.pptx), qui contient une image EMF avec des lignes diagonales rapprochées. L'exemple suivant exporte sa première diapositive à trois résolutions de rasterisation via [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/). Tous les autres paramètres d'exportation restent identiques afin que les résultats puissent être comparés.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"metafile-rasterization.pptx");
auto slide = presentation->get_Slide(0);
const int resolutions[] = { 72, 150, 300 };

for (auto dpi : resolutions)
{
    auto svgOptions = MakeObject<SVGOptions>();
    svgOptions->set_MetafileRasterizationDpi(dpi);
    svgOptions->set_PicturesCompression(PicturesCompression::Dpi330);
    svgOptions->set_JpegQuality(90);

    auto svgFileName = String::Format(u"slide-{0}.svg", dpi);
    auto svgStream = File::Create(svgFileName);
    slide->WriteAsSvg(svgStream, svgOptions);
    svgStream->Dispose();
}

presentation->Dispose();
```

Dans la sortie, l'EMF est devenu un PNG intégré dans chaque SVG. Les mesures suivantes concernent la présentation fournie ; elles ne constituent pas une formule générale de conversion DPI → dimensions en pixels.

| Résolution de rasterisation du métafichier DPI | Dimensions du PNG intégré | Taille du fichier SVG (octets) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

La comparaison ci‑dessous montre la même zone du raster intégré à la même taille d'affichage agrandie. Les lignes diagonales montrent une pixellisation visible à 72 DPI et des bords plus lisses à des résolutions supérieures, tandis que le fichier SVG augmente. Augmenter la valeur n'améliore pas forcément chaque détail ni ne modifie chaque image exportée.

![Détail agrandi des lignes diagonales à 72, 150 et 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) contrôle la réduction de résolution des images et peut masquer l'effet du changement de la résolution de rasterisation du métafichier. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) contrôle la qualité d'encodage JPEG, pas la résolution de rasterisation du métafichier.

## **Attribuer des ID stables aux formes et au texte**

Utilisez [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) pour définir [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) pour chaque forme SVG. Pour définir également les valeurs [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) sur les éléments `tspan` de texte, implémentez [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Assignez l'un ou l'autre contrôleur avec [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Le contrôleur suivant utilise [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/), qui est stable pendant la durée de vie de la forme, ainsi qu'un compteur répétable pour ses `tspan` de texte. Cela rend les ID générés adaptés au post‑traitement d'une présentation inchangée.

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Ajouter des gestionnaires d'événements SVG**

Dans un [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/), appelez [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) avec une valeur [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) pour ajouter un gestionnaire d'événement JavaScript à une forme exportée. Assignez le contrôleur avec [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) et définissez la fonction JavaScript dans la page ou le document SVG qui héberge le résultat.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

La page d'accueil peut définir la fonction JavaScript référencée par le gestionnaire. L'attribution d'ID et de gestionnaires d'événements permet aux visionneuses de diapositives, aux améliorations d'accessibilité et à d'autres flux de travail SVG interactifs.

## **FAQ**

**Quand faut‑il utiliser [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) au lieu de [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Utilisez [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) lorsque tout le texte doit être indépendant des polices. Utilisez [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) lorsque seul le texte qui utilise des polices externes doit être converti en graphiques.

**Quelle est la meilleure façon de réduire la taille d'un SVG ?**

Commencez par compresser les images intégrées, supprimer les zones d'image recadrées et choisir des fichiers de police liés lorsque l'environnement cible peut les servir. Testez le résultat car une résolution d'image plus faible, une qualité JPEG réduite et le texte vectorisé ont chacun des compromis différents en termes de qualité et de taille.

**Puis‑je modifier les éléments SVG exportés après l'exportation ?**

Oui. Attribuez des ID via un contrôleur de formatage, puis sélectionnez les éléments SVG correspondants dans votre outil de post‑traitement ou script de navigateur.