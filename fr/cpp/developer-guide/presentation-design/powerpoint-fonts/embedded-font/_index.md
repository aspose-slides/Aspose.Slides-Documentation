---
title: Police intégrée
type: docs
weight: 40
url: /cpp/embedded-font/
keywords: "Polices, polices intégrées, ajouter des polices, présentation PowerPoint C++, CPP, Aspose.Slides pour C++"
description: "Utilisez des polices intégrées dans une présentation PowerPoint en C++"
---

**Les polices intégrées dans PowerPoint** sont utiles lorsque vous souhaitez que votre présentation apparaisse correctement lorsqu'elle est ouverte sur n'importe quel système ou appareil. Si vous avez utilisé une police tierce ou non standard parce que vous avez été créatif dans votre travail, alors vous avez encore plus de raisons d'incorporer votre police. Sinon (sans polices intégrées), les textes ou les chiffres sur vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles confus.

La classe [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/), la classe [FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/), la classe [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) et leurs interfaces contiennent la plupart des propriétés et des méthodes dont vous avez besoin pour travailler avec des polices intégrées dans des présentations PowerPoint.

## **Obtenir ou supprimer des polices intégrées de la présentation**

Aspose.Slides fournit la méthode [GetEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) (exposée par la classe [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/)) pour vous permettre d'obtenir (ou de découvrir) les polices intégrées dans une présentation. Pour supprimer des polices, la méthode [RemoveEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/removeembeddedfont/) (exposée par la même classe) est utilisée.

Ce code C++ vous montre comment obtenir et supprimer des polices intégrées d'une présentation :

```c++
// Instancie un objet Presentation représentant un fichier de présentation
auto presentation = System::MakeObject<Presentation>(u"EmbeddedFonts.pptx");
// Rendu d'une diapositive contenant un cadre de texte qui utilise "FunSized" intégré
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"picture1_out.png", ImageFormat::Png);

auto fontsManager = presentation->get_FontsManager();

// Obtient toutes les polices intégrées
auto embeddedFonts = fontsManager->GetEmbeddedFonts();

std::function<bool(SharedPtr<IFontData>)> comparer = [](SharedPtr<IFontData> data) -> bool
{
    return data->get_FontName() == u"Calibri";
};

// Trouve la police "Calibri"
auto funSizedEmbeddedFont = Array<SharedPtr<IFontData>>::Find(embeddedFonts, comparer);

// Supprime la police "Calibri"
fontsManager->RemoveEmbeddedFont(funSizedEmbeddedFont);

// Rendu de la présentation ; la police "Calibri" est remplacée par une existante
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"picture2_out.png", ImageFormat::Png);

// Enregistre la présentation sans la police "Calibri" intégrée sur disque
presentation->Save(u"WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
```

## **Ajouter des polices intégrées à la présentation**

En utilisant l'énumération [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) et deux surcharges de la méthode [AddEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/), vous pouvez sélectionner votre règle préférée (d'incorporation) pour intégrer les polices dans une présentation. Ce code C++ vous montre comment incorporer et ajouter des polices à une présentation :

```c++
// Charge la présentation
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Charge la police source à remplacer
auto sourceFont = System::MakeObject<FontData>(u"Arial");

auto allFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (SharedPtr<IFontData> font : allFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&font](SharedPtr<IFontData> data) -> bool
    {
        return data == font;
    };

    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        presentation->get_FontsManager()->AddEmbeddedFont(font, EmbedFontCharacters::All);
    }
}

// Enregistre la présentation sur disque
presentation->Save(u"AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
```

## **Compresser les polices intégrées**

Pour vous permettre de compresser les polices intégrées dans une présentation et de réduire sa taille de fichier, Aspose.Slides fournit la méthode [CompressEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) (exposée par la classe [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)).

Ce code C++ vous montre comment compresser les polices PowerPoint intégrées :

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

Aspose::Slides::LowCode::Compress::CompressEmbeddedFonts(pres);
pres->Save(u"pres-out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```