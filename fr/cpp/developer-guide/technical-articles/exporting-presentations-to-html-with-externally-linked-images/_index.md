---
title: Exportation de présentations vers HTML avec des images liées externément
type: docs
weight: 50
url: /fr/cpp/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

Cet article décrit une technique avancée qui permet de contrôler quelles ressources sont intégrées dans le fichier HTML résultant et lesquelles sont enregistrées en externes et référencées depuis le fichier HTML.

{{% /alert %}} 
## **Contexte**
Le comportement par défaut de l'exportation HTML est d'incorporer toute ressource dans le fichier HTML. Un tel approche entraîne un fichier HTML unique qui est facile à visualiser et à distribuer. Toutes les ressources nécessaires sont encodées en base64 à l'intérieur. Mais cette approche présente deux inconvénients :

- La taille de la sortie est considérablement plus grande en raison de l'encodage en base64. Il est difficile de remplacer les images contenues dans le fichier.

Dans cet article, nous allons voir comment nous pouvons changer le comportement par défaut en utilisant **Aspose.Slides pour C++** pour lier les images de manière externe plutôt que de les intégrer dans le fichier HTML. Nous utiliserons l'interface [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller) qui contient trois méthodes pour contrôler le processus d'intégration et de sauvegarde des ressources. Nous pouvons passer cette interface au constructeur de la classe [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) lors de la préparation de l'exportation.

Voici le code complet de la classe **LinkController** qui implémente l'interface [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller). Comme mentionné précédemment, le **LinkController** doit implémenter l'interface [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller). Cette interface spécifie trois méthodes :

- **LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, String semanticName, String contentType, String recomendedExtension)** Elle est appelée lorsque l'exportateur rencontre une ressource et doit décider comment la stocker. Les paramètres les plus importants sont 'id' – l'identifiant unique de la ressource pour toute l'opération d'exportation et 'contentType' – contient le type MIME de la ressource. Si nous décidons de lier la ressource, nous devons retourner LinkEmbedDecision::Link depuis cette méthode. Sinon, LinkEmbedDecision::Embed doit être retourné pour intégrer la ressource.
- **String GetUrl(int32_t id, int32_t referrer)**
  Elle est appelée pour obtenir l'URL de la ressource sous la forme dans laquelle elle est utilisée dans le fichier résultant, par exemple pour une balise ```<img src="%method_result_here%">```. La ressource est identifiée par 'id'.
- **SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData)** 
  La méthode finale de la séquence, elle est appelée lorsqu'il s'agit de stocker la ressource à l'extérieur. Nous avons l'identifiant de la ressource et le contenu de la ressource sous forme de tableau d'octets. C'est à nous de décider quoi faire avec les données de ressource fournies.

``` cpp
/// <summary>
/// Cette classe est responsable de la prise de décisions concernant les ressources enregistrées à l'extérieur.
/// Elle doit implémenter l'interface Aspose::Slides::Export::ILinkEmbedController.
/// </summary>
class LinkController : public ILinkEmbedController
{
public:
    LinkController()
    {
        m_externalImages = System::MakeObject<Dictionary<int32_t, String>>();
    }
    LinkController::LinkController(String savePath) : LinkController()
    {
        m_savePath = savePath;
    }

    LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, 
        String semanticName, String contentType, String recomendedExtension) override
    {
        // Ici nous prenons la décision concernant le stockage des images à l'extérieur.
        // L'id est l'identifiant unique de chaque objet pendant toute l'opération d'exportation.

        String template_;

        // Le dictionnaire s_templates contient les types de contenu que nous allons stocker à l'extérieur et le modèle de nom de fichier correspondant.
        if (s_templates->TryGetValue(contentType, template_))
        {
            // Stockage de cette ressource dans la liste d'exportation
            m_externalImages->Add(id, template_);
            return LinkEmbedDecision::Link;
        }

        // Toutes les autres ressources, le cas échéant, seront intégrées
        return LinkEmbedDecision::Embed;
    }

    String GetUrl(int32_t id, int32_t referrer) override
    {
        // Ici nous construisons la chaîne de référence de la ressource pour former la balise : <img src="%result%">
        // Nous devons vérifier le dictionnaire pour filtrer les ressources inutiles.
        // En même temps que la vérification, nous extrayons le modèle de nom de fichier correspondant.
        String template_;
        if (m_externalImages->TryGetValue(id, template_))
        {
            // Supposons que nous allons stocker les fichiers de ressources juste à côté du fichier HTML.
            // La balise image ressemblera à <img src="image-1.png"> avec l'identifiant de ressource correspondant et l'extension.
            String fileUrl = String::Format(template_, id);
            return fileUrl;
        }

        // null doit être retourné pour les ressources restant intégrées
        return nullptr;
    }

    void SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData) override
    {
        // Ici nous sauvegardons effectivement les fichiers de ressources sur le disque.
        // Encore une fois, vérifiant le dictionnaire. Si l'id n'est pas trouvé ici, cela signifie une erreur dans les méthodes GetObjectStoringLocation ou GetUrl.
        if (m_externalImages->ContainsKey(id))
        {
            // Maintenant, nous utilisons le nom de fichier stocké dans le dictionnaire et le combinons avec un chemin selon les besoins.

            // Construction du nom de fichier en utilisant le modèle stocké et l'Id.
            String fileName = String::Format(m_externalImages->idx_get(id), id);
            
            // Combinaison avec le répertoire de localisation
            const String savePath = m_savePath != nullptr ? m_savePath : String::Empty;
            String filePath = Path::Combine(savePath, fileName);

            auto fs = System::MakeObject<FileStream>(filePath, FileMode::Create);
            fs->Write(entityData, 0, entityData->get_Length());
        }
        else
        {
            throw Exception(u"Quelque chose ne va pas");
        }
    }

private:
    String m_savePath;
    SharedPtr<Dictionary<int32_t, String>> m_externalImages;
    static SharedPtr<Dictionary<String, String>> s_templates;

    static struct __StaticConstructor__
    {
        __StaticConstructor__()
        {
            s_templates->Add(u"image/jpeg", u"image-{0}.jpg");
            s_templates->Add(u"image/png", u"image-{0}.png");
        }
    } s_constructor__;
};
```

Après avoir écrit la classe **LinkController**, nous allons maintenant l'utiliser avec la classe [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) pour exporter la présentation vers HTML en ayant des images liées externément en utilisant le code suivant.

``` cpp
const String templatePath = u"../templates/image.pptx";
auto pres = System::MakeObject<Presentation>(templatePath);

auto htmlOptions = System::MakeObject<HtmlOptions>(System::MakeObject<LinkController>(GetOutPath()));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(System::MakeObject<SVGOptions>()));
// Cette ligne est nécessaire pour supprimer l'affichage du titre de la diapositive dans HTML.
// Commentez-le si vous préférez afficher le titre de la diapositive.
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));

pres->Save(GetOutPath() + u"/output.html", SaveFormat::Html, htmlOptions);
```

Nous passons **SlideImageFormat::Svg** à la méthode **set_SlideImageFormat** ce qui signifie que le fichier HTML résultant contiendra des données SVG à l'intérieur pour dessiner le contenu de la présentation.

Quant aux types de contenu, ils dépendent des données d'image réelles contenues dans la présentation. S'il y a des bitmaps raster dans la présentation, le code de la classe doit être prêt à traiter à la fois les types de contenu 'image/jpeg' et 'image/png'. Le type de contenu réel des bitmaps raster exportés peut ne pas correspondre au type de contenu des images stockées dans la présentation. Les algorithmes internes d'Aspose.Slides pour C++ effectuent une optimisation de taille et utilisent soit le codec JPG soit le codec PNG, selon celui qui génère une taille de données plus petite. Les images contenant un canal alpha (transparence) sont toujours encodées en PNG.