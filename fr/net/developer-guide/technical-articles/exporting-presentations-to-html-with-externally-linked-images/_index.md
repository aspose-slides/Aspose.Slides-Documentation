---
title: Exportation de présentations en HTML avec des images liées externement
type: docs
weight: 100
url: /net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

La procédure d'exportation de présentation en HTML ici vous permet de spécifier

1. les ressources qui seront intégrées dans le fichier HTML résultant
2. les ressources qui seront enregistrées en externe et référencées depuis le fichier HTML.

{{% /alert %}} 

## **Contexte**

Le comportement par défaut d'exportation en HTML est d'intégrer toutes les ressources dans le fichier HTML par encodage base64. Une telle approche produit un seul fichier HTML, ce qui est pratique pour la visualisation et la distribution. L'approche par défaut souffre des limitations suivantes :

* le fichier produit est significativement plus lourd que ses constituants en raison de l'encodage base64.
* les images ou ressources contenues dans le fichier sont difficiles à remplacer.

### **Une approche différente**

Une approche différente impliquant **[ILinkEmbedController](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/)** évite les limitations énumérées.  

La classe `LinkController` implémente l'interface `ILinkEmbedController`. L'interface est ensuite transmise au constructeur de la classe [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/htmloptions/#constructor). L'interface ILinkEmbedController contient trois méthodes qui contrôlent le processus d'intégration et d'enregistrement des ressources :

**[GetObjectStoringLocation](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation)(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)** : Cette méthode est appelée lorsque l'exportateur rencontre une ressource et doit décider comment stocker cette ressource. *id* (identifiant unique de la ressource pour l'opération d'exportation) et *contentType* (contenant le type MIME de la ressource) sont les paramètres les plus importants sous cette méthode. Si vous souhaitez lier la ressource, vous devez retourner l'énumération [LinkEmbedDecision.Link](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/) depuis la méthode. Sinon (pour intégrer la ressource), vous devez retourner [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/).

**[GetUrl](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/geturl)(int id, int referrer)** : Cette méthode est appelée pour obtenir l'URL de la ressource de la même manière qu'elle est utilisée dans le fichier résultant. La ressource est identifiée par *id*.

**[SaveExternal](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/saveexternal)(int id, byte[] entityData)** : En tant que dernière méthode de la séquence, elle est appelée lorsqu'il est temps que la ressource soit stockée en externe. Étant donné que l'identifiant de la ressource et le contenu de la ressource existent dans un tableau d'octets, vous pouvez effectuer toutes sortes de tâches avec les données de la ressource.

Ce code C# pour la classe **LinkController** implémente l'interface **ILinkEmbedController** :

```c#
class LinkController : ILinkEmbedController
{
    static LinkController()
    {
        s_templates.Add("image/jpeg", "image-{0}.jpg");
        s_templates.Add("image/png", "image-{0}.png");
    }

    /// <summary>
    /// Constructeur par défaut sans paramètre
    /// </summary>
    public LinkController()
    {
        m_externalImages = new Dictionary<int, string>();
    }

    /// <summary>
    /// Crée une instance de classe et définit le chemin où les fichiers de ressources générés seront enregistrés.
    /// </summary>
    /// <param name="savePath">Chemin vers l'emplacement où les fichiers de ressources générés seront stockés.</param>
    public LinkController(string savePath)
        : this()
    {
        SavePath = savePath;
    }

    /// <summary>
    /// Un membre de ILinkEmbedController
    /// </summary>
    public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName,
        string contentType,
        string recomendedExtension)
    {
        // Ici, nous prenons la décision de stocker les images en externe.
        // L'id est l'identifiant unique de chaque objet durant toute l'opération d'exportation.

        string template;

        // Le dictionnaire s_templates contient les types de contenu que nous allons stocker en externe et le modèle de nom de fichier correspondant.
        if (s_templates.TryGetValue(contentType, out template))
        {
            // Stocker cette ressource dans la liste d'exportation
            m_externalImages.Add(id, template);
            return LinkEmbedDecision.Link;
        }

        // Toutes les autres ressources, le cas échéant, seront intégrées
        return LinkEmbedDecision.Embed;
    }

    /// <summary>
    /// Un membre de ILinkEmbedController
    /// </summary>
    public string GetUrl(int id, int referrer)
    {
        // Ici, nous construisons la chaîne de référence de la ressource pour former la balise : <img src="%result%">
        // Nous devons vérifier le dictionnaire pour filtrer les ressources inutiles.
        // En vérifiant, nous extrayons le modèle de nom de fichier correspondant.
        string template;
        if (m_externalImages.TryGetValue(id, out template))
        {
            // En supposant que nous allons stocker les fichiers de ressources juste à côté du fichier HTML.
            // La balise image ressemblera à <img src="image-1.png"> avec l'identifiant et l'extension de ressource appropriés.
            var fileUrl = String.Format(template, id);
            return fileUrl;
        }

        // null doit être retourné pour les ressources restant intégrées
        return null;
    }

    /// <summary>
    /// Un membre de ILinkEmbedController
    /// </summary>
    public void SaveExternal(int id, byte[] entityData)
    {
        // Ici, nous sauvegardons réellement les fichiers de ressources sur disque.
        // Encore une fois, nous vérifions le dictionnaire. Si l'id n'est pas trouvé ici, cela est un signe d'erreur dans les méthodes GetObjectStoringLocation ou GetUrl.
        if (m_externalImages.ContainsKey(id))
        {
            // Maintenant, nous utilisons le nom de fichier stocké dans le dictionnaire et le combinons avec un chemin comme requis.

            // Construction du nom de fichier en utilisant le modèle stocké et l'Id.
            var fileName = String.Format(m_externalImages[id], id);

            // Combinaison avec le répertoire de destination
            var filePath = Path.Combine(SavePath ?? String.Empty, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
                fs.Write(entityData, 0, entityData.Length);
        }
        else
            throw new Exception("Quelque chose ne va pas");
    }

    /// <summary>
    /// Obtient ou définit le chemin où les fichiers de ressources générés seront sauvegardés.
    /// </summary>
    public string SavePath { get; set; }

    /// <summary>
    /// Un dictionnaire pour stocker les associations entre les ids de ressources et les noms de fichiers correspondants.
    /// </summary>
    private readonly Dictionary<int, string> m_externalImages;

    /// <summary>
    /// Un dictionnaire pour stocker les associations entre les types de contenu des ressources que nous allons stocker en externe
    /// et les modèles de noms de fichiers correspondants.
    /// </summary>
    private static readonly Dictionary<string, string> s_templates = new Dictionary<string, string>();
}
```

Après avoir écrit la classe **LinkController**, nous pouvons maintenant l'utiliser avec la classe **HTMLOptions** pour exporter la présentation en HTML avec des images liées externement de cette manière :

```c#
using (var pres = new Presentation(@"C:\data\input.pptx")) {

    var htmlOptions = new HtmlOptions(new LinkController(@"C:\data\out\"));
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());
    // Cette ligne est nécessaire pour supprimer l'affichage du titre de la diapositive en HTML.
    // Décommentez-la si vous préférez que le titre de la diapositive soit affiché.
    htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(String.Empty, false);

    Console.WriteLine("Démarrage de l'exportation");
    pres.Save(@"C:\data\out\output.html", SaveFormat.Html, htmlOptions);
}
```

Nous avons assigné `SlideImageFormat.Svg` à la propriété `SlideImageFormat` afin que le fichier HTML résultant contienne des données SVG pour dessiner le contenu de la présentation.

Types de contenu : Si la présentation contient des images bitmap raster, alors le code de la classe doit être préparé à traiter à la fois les types de contenu 'image/jpeg' et 'image/png'. Le contenu des images bitmap exportées peut ne pas correspondre à ce qui a été enregistré dans la présentation. Les algorithmes internes d'Aspose.Slides effectuent l'optimisation de taille et utilisent soit le codec JPG soit le codec PNG (en fonction de celui qui génère une taille de données plus petite). Les images contenant un canal alpha (transparence) sont toujours encodées en PNG.