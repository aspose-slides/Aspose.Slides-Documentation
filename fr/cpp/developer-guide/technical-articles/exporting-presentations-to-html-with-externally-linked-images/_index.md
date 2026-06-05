---
title: Exporter des présentations au format HTML avec des images liées externement
type: docs
weight: 50
url: /fr/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter présentation
- exporter diapositive
- exporter PPT
- exporter PPTX
- exporter ODP
- PowerPoint vers HTML
- OpenDocument vers HTML
- présentation vers HTML
- diapositive vers HTML
- PPT vers HTML
- PPTX vers HTML
- ODP vers HTML
- image liée
- image liée externement
- ressource liée
- ressource externe
- C++
- Aspose.Slides
description: "Exporter des présentations PowerPoint et OpenDocument au format HTML en C++ à l'aide d'Aspose.Slides avec les images et autres ressources enregistrées en fichiers liés externes."
---
## **Aperçu**

Par défaut, Aspose.Slides exporte une présentation vers un fichier HTML autonome. Les images et autres ressources sont écrites directement dans le HTML, généralement sous forme de données Base64. Cela est pratique lorsque vous avez besoin d'un seul fichier portable, mais ce n'est pas toujours le meilleur format pour un site web, un CMS ou une chaîne de conversion côté serveur.

Utilisez des ressources liées externes lorsque vous voulez :

- réduire la taille du document HTML ;
- mettre en cache les images, polices, audio ou vidéo séparément dans un navigateur ou un CDN ;
- inspecter, remplacer, compresser ou post‑traiter les ressources générées après l'exportation ;
- garder la structure de sortie plus proche de ce qu’une application web attend.

Pour le flux de travail général de conversion HTML, voir [Convertir des présentations PowerPoint en HTML](/slides/fr/cpp/convert-powerpoint-to-html/). Cet article se concentre sur la partie liaison des ressources de l’exportation.

## **Comment fonctionne l'exportation de ressources liées**

[ILinkEmbedController](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ilinkembedcontroller/) laisse votre application décider, ressource par ressource, si l'exportateur doit intégrer les données dans le HTML ou les enregistrer à l'extérieur et écrire un lien.

L'interface possède trois méthodes :

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) décide si une ressource doit être liée ou intégrée.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) renvoie l'URL qui sera écrite dans le HTML généré ou dans une autre ressource liée.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) écrit les données de la ressource liée sur le disque ou vers une autre cible de stockage.

Le chemin du système de fichiers et l'URL du navigateur sont des préoccupations distinctes. Par exemple, l'exemple ci‑dessous écrit les fichiers de ressources dans `html-output/assets` sur le disque, tandis que le HTML contient des URL relatives telles que `assets/resource-1.svg`. Un navigateur résout ces URL par rapport au fichier qui contient le lien. Ainsi, un lien de `presentation.html` vers un fichier SVG utilise `assets/resource-1.svg`, tandis qu'un lien de ce fichier SVG vers une image enregistrée dans le même dossier `assets` utilise `resource-4.jpg`.

## **Exporter du HTML avec des ressources liées**

L'exemple C++ suivant crée un répertoire de sortie, y enregistre le fichier HTML et stocke les ressources liées dans un sous‑dossier `assets`. Le contrôleur lie les images, polices, audio, vidéo et ressources CSS courantes lorsque Aspose.Slides fournit ou peut déduire une extension de fichier sûre. Les ressources non reconnues restent intégrées.

```cpp
class ExternalResourceController : public ILinkEmbedController
{
public:
    ExternalResourceController(String assetDirectory, String assetUrlPrefix)
    {
        if (IsNullOrWhiteSpace(assetDirectory))
        {
            throw Exception(u"The asset output directory must not be empty.");
        }

        m_assetDirectory = assetDirectory;
        m_assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
        m_fileNamesByResourceId = MakeObject<Dictionary<int, String>>();
    }

    LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        ArrayPtr<uint8_t> entityData,
        String semanticName,
        String contentType,
        String recommendedExtension) override
    {
        auto extension = ResolveExtension(contentType, recommendedExtension);
        if (String::IsNullOrEmpty(extension))
        {
            return LinkEmbedDecision::Embed;
        }

        auto fileName = String::Format(u"resource-{0}{1}", resourceId, extension);
        m_fileNamesByResourceId->Add(resourceId, fileName);
        return LinkEmbedDecision::Link;
    }

    String GetUrl(int resourceId, int referrer) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            return nullptr;
        }

        if (m_fileNamesByResourceId->ContainsKey(referrer))
        {
            return fileName;
        }

        return m_assetUrlPrefix + fileName;
    }

    void SaveExternal(int resourceId, ArrayPtr<uint8_t> entityData) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            auto message = String::Format(u"Resource {0} was not registered for external storage.", resourceId);
            throw Exception(message);
        }

        if (entityData == nullptr || entityData->get_Length() == 0)
        {
            auto message = String::Format(u"Resource {0} contains no data and cannot be saved.", resourceId);
            throw Exception(message);
        }

        Directory::CreateDirectory_(m_assetDirectory);

        auto filePath = Path::Combine(m_assetDirectory, fileName);
        auto fileStream = MakeObject<FileStream>(filePath, FileMode::Create, FileAccess::Write);
        fileStream->Write(entityData, 0, entityData->get_Length());
        fileStream->Close();
    }

private:
    String m_assetDirectory;
    String m_assetUrlPrefix;
    SharedPtr<Dictionary<int, String>> m_fileNamesByResourceId;

    static SharedPtr<Dictionary<String, String>> GetExtensionsByContentType()
    {
        auto extensionsByContentType = MakeObject<Dictionary<String, String>>();
        extensionsByContentType->Add(u"image/jpeg", u".jpg");
        extensionsByContentType->Add(u"image/png", u".png");
        extensionsByContentType->Add(u"image/gif", u".gif");
        extensionsByContentType->Add(u"image/bmp", u".bmp");
        extensionsByContentType->Add(u"image/svg+xml", u".svg");
        extensionsByContentType->Add(u"image/tiff", u".tiff");
        extensionsByContentType->Add(u"image/x-emf", u".emf");
        extensionsByContentType->Add(u"image/x-wmf", u".wmf");
        extensionsByContentType->Add(u"font/woff", u".woff");
        extensionsByContentType->Add(u"font/woff2", u".woff2");
        extensionsByContentType->Add(u"font/ttf", u".ttf");
        extensionsByContentType->Add(u"application/font-woff", u".woff");
        extensionsByContentType->Add(u"application/vnd.ms-fontobject", u".eot");
        extensionsByContentType->Add(u"application/x-font-ttf", u".ttf");
        extensionsByContentType->Add(u"text/css", u".css");
        extensionsByContentType->Add(u"audio/mpeg", u".mp3");
        extensionsByContentType->Add(u"audio/mp4", u".m4a");
        extensionsByContentType->Add(u"audio/wav", u".wav");
        extensionsByContentType->Add(u"video/mp4", u".mp4");
        extensionsByContentType->Add(u"video/webm", u".webm");
        return extensionsByContentType;
    }

    static String ResolveExtension(String contentType, String recommendedExtension)
    {
        auto normalizedContentType = NormalizeContentType(contentType);
        auto extensionsByContentType = GetExtensionsByContentType();

        String mappedExtension;
        if (!String::IsNullOrEmpty(normalizedContentType) &&
            extensionsByContentType->TryGetValue(normalizedContentType, mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(normalizedContentType))
        {
            return nullptr;
        }

        return NormalizeExtension(recommendedExtension);
    }

    static bool IsSupportedContentType(String contentType)
    {
        return !String::IsNullOrEmpty(contentType) &&
            (contentType.StartsWith(u"image/") ||
                contentType.StartsWith(u"font/") ||
                contentType.StartsWith(u"audio/") ||
                contentType.StartsWith(u"video/"));
    }

    static String NormalizeContentType(String contentType)
    {
        if (IsNullOrWhiteSpace(contentType))
        {
            return nullptr;
        }

        return contentType.Trim().ToLowerInvariant();
    }

    static String NormalizeExtension(String extension)
    {
        if (IsNullOrWhiteSpace(extension))
        {
            return nullptr;
        }

        auto extensionCharacters = extension.Trim();
        if (extensionCharacters.StartsWith(u"."))
        {
            extensionCharacters = extensionCharacters.Substring(1);
        }

        if (String::IsNullOrEmpty(extensionCharacters))
        {
            return nullptr;
        }

        auto extensionLength = extensionCharacters.get_Length();
        for (int index = 0; index < extensionLength; index++)
        {
            auto character = extensionCharacters[index];
            if (!Char::IsLetterOrDigit(character))
            {
                return nullptr;
            }
        }

        return u"." + extensionCharacters.ToLowerInvariant();
    }

    static String NormalizeUrlPrefix(String urlPrefix)
    {
        if (String::IsNullOrEmpty(urlPrefix))
        {
            return String::Empty;
        }

        auto normalizedUrlPrefix = urlPrefix.Replace(u"\\", u"/");
        if (normalizedUrlPrefix.EndsWith(u"/"))
        {
            return normalizedUrlPrefix;
        }

        return normalizedUrlPrefix + u"/";
    }

    static bool IsNullOrWhiteSpace(String value)
    {
        return String::IsNullOrEmpty(value) || String::IsNullOrEmpty(value.Trim());
    }
};
```
```cpp
auto inputFilePath = String(u"presentation.pptx");
auto outputDirectory = String(u"html-output");
auto assetDirectoryName = String(u"assets");
auto assetDirectory = Path::Combine(outputDirectory, assetDirectoryName);

Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(assetDirectory);

auto assetUrlPrefix = assetDirectoryName + u"/";
auto controller = MakeObject<ExternalResourceController>(assetDirectory, assetUrlPrefix);
auto svgOptions = MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto presentation = MakeObject<Presentation>(inputFilePath);

auto htmlFilePath = Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);
presentation->Dispose();
```

Après l'exportation, le dossier de sortie a la structure suivante :

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Les fichiers exacts dépendent du contenu de la présentation et des options d'exportation. Par exemple, les images matricielles sont généralement exportées en JPEG ou PNG. Aspose.Slides peut choisir un codec d'image différent de celui utilisé dans la présentation source lorsqu’il produit un fichier plus petit ou plus adapté. Les images avec transparence sont exportées en PNG.

## **Choisir les URL pour le déploiement**

L'exemple utilise un préfixe d'URL relatif : `assets/`. Si `presentation.html` est ouvert depuis `html-output/presentation.html`, le navigateur charge `html-output/assets/resource-1.svg`.

Lorsque une ressource liée fait référence à une autre ressource liée, l'exemple utilise le paramètre `referrer` dans [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) et ne renvoie que le nom de fichier. Par exemple, si `resource-1.svg` et `resource-4.jpg` se trouvent tous deux dans le dossier `assets`, le fichier SVG doit référencer `resource-4.jpg`, et non `assets/resource-4.jpg`.

Utilisez un préfixe d'URL différent lorsque les fichiers sont déployés ailleurs :

- Utilisez `assets/` lorsque le répertoire des actifs se trouve à côté du fichier HTML.
- Utilisez `../assets/` lorsque le répertoire des actifs est un niveau au‑dessus du fichier HTML.
- Utilisez `https://cdn.example.com/presentations/job-123/assets/` lorsque les fichiers sont téléchargés vers un CDN ou un serveur de fichiers statiques.

L'URL renvoyée par [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) doit correspondre à l’emplacement final déployé du fichier écrit par [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/). Dans les applications serveur, utilisez un répertoire de sortie unique ou un préfixe de stockage d’objet pour chaque tâche de conversion afin d'éviter d'écraser les fichiers d’une autre exportation.

## **Quand intégrer à la place**

Le HTML intégré en Base64 reste utile lorsque la sortie doit être un seul fichier, comme une pièce jointe d’e‑mail, un aperçu hors ligne ou un document qui sera déplacé sans dossier d’actifs de soutien. Les ressources liées sont plus appropriées lorsque le HTML sera servi par une application web, stocké dans un CMS, optimisé par une chaîne de construction ou mis en cache par les navigateurs indépendamment du HTML.

## **FAQ**

**Puis‑je externaliser uniquement les images et garder les autres ressources intégrées ?**

Oui. Dans [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), renvoyez `LinkEmbedDecision::Link` uniquement pour les types de contenu que vous souhaitez enregistrer en fichiers séparés, et renvoyez `LinkEmbedDecision::Embed` pour tout le reste.

**Pourquoi l’extension de l’image exportée diffère‑t‑elle de celle de la présentation source ?**

Aspose.Slides peut ré‑encoder les images matricielles lors de l’exportation HTML afin d’améliorer la taille ou la compatibilité avec les navigateurs. Par exemple, une image du fichier source peut être écrite en JPEG ou PNG selon le résultat rendu.

**Les URL relatives fonctionnent‑elles après avoir déplacé le fichier HTML ?**

Les URL relatives ne fonctionnent que lorsque la même structure de dossiers relative est préservée. Si le HTML référence `assets/resource-1.png`, le dossier `assets` doit rester à côté du fichier HTML à moins que vous ne génériez un préfixe d’URL différent.

**Les applications serveur doivent‑elles réutiliser le même dossier de sortie ?**

Non. Utilisez un répertoire de sortie unique ou un préfixe de stockage pour chaque tâche de conversion. Cela évite les collisions de noms de fichiers et empêche une exportation d’écraser les ressources générées par une autre exportation.