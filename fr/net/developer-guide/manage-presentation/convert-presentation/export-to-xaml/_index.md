---
title: Exporter des présentations en XAML dans .NET
linktitle: Présentation en XAML
type: docs
weight: 30
url: /fr/net/export-to-xaml/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter une présentation
- convertir PowerPoint
- convertir OpenDocument
- convertir une présentation
- PowerPoint vers XAML
- OpenDocument vers XAML
- présentation vers XAML
- PPT vers XAML
- PPTX vers XAML
- ODP vers XAML
- enregistrer PPT en XAML
- enregistrer PPTX en XAML
- enregistrer ODP en XAML
- exporter PPT en XAML
- exporter PPTX en XAML
- exporter ODP en XAML
- .NET
- C#
- Aspose.Slides
description: "Convertir les diapositives PowerPoint et OpenDocument en XAML dans .NET avec Aspose.Slides — solution rapide, sans Office, qui préserve votre mise en page."
---
## **Aperçu**

Cet article explique comment exporter des présentations PowerPoint au format XAML à l’aide d’Aspose.Slides. Il comprend une brève introduction à XAML, montre comment enregistrer une présentation en XAML avec les paramètres par défaut et démontre comment personnaliser l’exportation via [XamlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/xamloptions/), y compris l’exportation des diapositives masquées. L’article répond également à quelques questions fréquentes concernant les polices de secours, la compatibilité des piles XAML et le comportement d’exportation des diapositives masquées.

## **À propos de XAML**

XAML est un langage de balisage basé sur XML utilisé pour décrire les interfaces utilisateur dans des frameworks tels que WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin.Forms.

Vous pouvez travailler avec des fichiers XAML dans un concepteur visuel ou écrire et modifier le marquage directement.

## **Exporter des présentations en XAML avec les options par défaut**

L’exemple C# suivant montre comment exporter une présentation en XAML avec les paramètres par défaut :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Par défaut, les diapositives exportées sont enregistrées dans un sous‑dossier `pres` du répertoire de travail actuel du processus, tel que renvoyé par [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). Le dossier est créé automatiquement et toutes les images nécessaires y sont également enregistrées.

Le nom du dossier de sortie est dérivé du nom du fichier source sans son extension. Pour `pres.pptx`, les fichiers de sortie sont nommés `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Même si vous fournissez un chemin absolu vers la présentation d’entrée, le dossier de sortie est créé relativement au répertoire de travail actuel, et non à côté du fichier d’entrée.

## **Exporter des présentations en XAML avec des options personnalisées**

Utilisez l’interface [IXamlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/ixamloptions/) pour contrôler la façon dont Aspose.Slides exporte une présentation en XAML.

Pour enregistrer la sortie à un emplacement personnalisé, implémentez [IXamlOutputSaver](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/ixamloutputsaver/) et attribuez une instance de votre implémentation à la propriété [OutputSaver](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/xamloptions/outputsaver/) de [XamlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/xamloptions/).

Pour inclure les diapositives masquées dans la sortie XAML, définissez la propriété [ExportHiddenSlides](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) sur `true`, comme le montre l’exemple C# suivant :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Capturer tous les artefacts XAML générés**

Une exportation XAML peut produire un document XAML pour chaque diapositive exportée ainsi que des images séparées et des ressources de prise en charge. Assignez un [IXamlOutputSaver](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/ixamloutputsaver/) personnalisé à [XamlOptions.OutputSaver](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/xamloptions/outputsaver/) pour recevoir ces artefacts au lieu d’utiliser le sauvegardeur de système de fichiers par défaut. Démarrez l’exportation avec la surcharge spécifique à XAML de [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) qui accepte les options XAML.

### **Comprendre le cycle de vie du rappel**

L’exportateur appelle [IXamlOutputSaver.Save](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/ixamloutputsaver/save/) séparément pour chaque artefact généré :

- `path` identifie l’artefact et peut contenir des répertoires relatifs. Conservez cette information car XAML peut référencer des ressources à l’aide de chemins relatifs.
- `data` contient les octets de l’artefact. Les images et autres ressources binaires ne doivent pas être décodées en texte.
- Le sauvegardeur est responsable de retenir ou de persister les données avant de revenir. Les exemples copient chaque tableau d’octets dans une mémoire appartenant à l’application.
- Considérez l’exportation comme réussie uniquement lorsque l’opération d’enregistrement de la présentation renvoie et que chaque rappel s’est terminé avec succès. Ne supprimez pas les erreurs de stockage et n’initéz pas d’écritures en arrière‑plan non observées. Si la persistance se produit ultérieurement, signalez le succès global uniquement après que cette étape ait également réussi.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) s’applique également à un sauvegardeur personnalisé. Sa valeur par défaut, `false`, exclut les documents XAML des diapositives masquées. Le passer à `true` les inclut ainsi que toutes les ressources requises pour leur exportation. Le nombre de ressources dépend de la présentation ; ne supposez pas un rappel par diapositive ou un ordre de rappel fixe.

### **Exporter en mémoire et inspecter les artefacts**

Cet exemple complet charge `pres.pptx`, collecte chaque artefact dans un [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) et affiche son nom, son type et son nombre d’octets. Il préserve exactement les noms fournis. Des noms en double entraînent l’échec de la collection plutôt qu’un écrasement silencieux d’un artefact.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Décoder uniquement le XAML, et seulement lorsque l'inspection textuelle est nécessaire.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Appelez `InMemoryXamlExample.Run` depuis votre application. Les vérifications d’extension sont utiles pour l’inspection ; conservez tous les artefacts, y compris les types de ressources inconnus. Laissez les octets inchangés lors du stockage ou de la transmission. Utilisez [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) uniquement pour le XAML qui nécessite un traitement textuel.

### **Emballer les artefacts collectés dans une archive ZIP**

Cet exemple autonome collecte l’exportation, valide ses noms et écrit les octets d’origine dans une archive ZIP. Un nom d’archive unique sépare les travaux d’exportation concurrents. Les entrées ZIP utilisent des barres obliques avant et conservent les répertoires relatifs. Les noms dangereux ou ceux qui entrent en collision après normalisation rejettent l’ensemble du paquet avant son écriture.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // Le répertoire ZIP a été finalisé lors de la libération avant de signaler le succès.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Appelez `ZipXamlExample.Run` depuis votre application. L’exemple utilise [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) pour écrire une archive locale ; l’exportateur lui‑même n’écrit pas de fichiers XAML ou image isolés. Pour le stockage à distance, remplacez l’étape d’écriture d’archive par des téléchargements des tableaux d’octets collectés. Utilisez un identifiant de travail d’exportation plus le nom d’artefact relatif complet comme clé de blob, ou stockez l’identifiant du travail, le nom relatif et les données binaires dans une ligne de base de données. Publiez le travail uniquement après que tous les téléchargements soient terminés ou que la transaction de base de données soit validée. Nettoyez la sortie partielle en cas d’échec de persistance.

Pour de grandes présentations, un sauvegardeur personnalisé peut persister chaque artefact directement dans le stockage de l’application afin d’éviter de garder une copie supplémentaire de l’ensemble de l’exportation en mémoire. L’exportateur continue de collecter tous les artefacts générés en mémoire avant d’appeler le sauvegardeur. Gardez chaque rappel synchronisé du point de vue de l’exportateur : ne revenez qu’après que la destination ait accepté les octets, et laissez les échecs remonter à l’appelant.

### **Conserver les noms des ressources et vérifier les références**

- Normalisez les séparateurs de chemin lorsque la destination l’exige, mais préservez les répertoires relatifs. N’utilisez pas uniquement [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) à moins que chaque nom généré ne soit garanti d’être unique et que les références aux ressources restent valides.
- Appliquez une validation des noms propre à la destination. Lors de l’écriture de fichiers isolés, rejetez les chemins ancrés et les segments de traversée, résolvez la destination avec [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) et vérifiez qu’elle reste en dessous du répertoire d’exportation prévu, en incluant le séparateur de répertoire dans la vérification de containment. Utilisez un répertoire contrôlé par l’application sans liens symboliques pouvant rediriger les écritures.
- Utilisez un sauvegardeur et un espace de noms de stockage distincts pour chaque travail d’exportation. Détectez les collisions après normalisation des séparateurs et selon les règles de sensibilité à la casse de la destination.
- Avant la publication, analysez chaque document XAML comme du XML et examinez ses références de ressources basées sur des fichiers, telles que les attributs `Source` ou `ImageSource` des images. Résolvez chaque URI relative par rapport au répertoire de l’artefact XAML contenant, normalisez le nom de stockage résultant et confirmez que la clé de dictionnaire correspondante, l’entrée ZIP ou l’objet stocké existe. Traitez séparément les URI externes et les expressions de balisage XAML des noms de fichiers relatifs.

Par exemple, si `pres/Slide_1.xaml` référence `images/image1.png`, la ressource stockée doit être disponible sous `pres/images/image1.png`. Conserver uniquement `image1.png` rompt cette relation. Pour le stockage d’objets, préservez la même hiérarchie sous le préfixe du travail et rendez ces URL de ressources accessibles au consommateur XAML. Rouvrez le ZIP final pour vérifier les noms d’entrée et les octets des ressources, et chargez des diapositives représentatives dans l’environnement XAML cible afin de confirmer que les images se résolvent correctement.

## **FAQ**

**Comment garantir des polices prévisibles si la police d'origine n'est pas disponible sur la machine ?**

Définissez [DefaultRegularFont](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveoptions/defaultregularfont/) dans [XamlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/xamloptions/) — il est utilisé comme police de secours pendant l’exportation lorsque la police d’origine est absente. Cela ne garantit pas que le XAML généré fasse référence à la police de secours ou que la police soit disponible sur la machine cible. Assurez‑vous que les polices référencées par le XAML soient présentes dans l’environnement où il est affiché.

**Le XAML exporté est‑il destiné uniquement à WPF, ou peut‑il être utilisé dans d’autres piles XAML également ?**

Aspose.Slides exporte du XAML WPF via son API publique. La compatibilité avec d’autres piles XAML, telles que UWP et Xamarin.Forms, n’est pas garantie. Testez le balisage généré dans votre environnement cible.

**Les diapositives masquées sont‑elles prises en charge, et comment empêcher leur exportation par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [ExportHiddenSlides](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) dans [XamlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/xamloptions/) — laissez‑le désactivé si vous n’avez pas besoin de les exporter.