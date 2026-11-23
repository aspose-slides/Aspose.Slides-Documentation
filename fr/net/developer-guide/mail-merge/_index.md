---
title: Automatiser la personnalisation des présentations avec le publipostage
linktitle: Publipostage
type: docs
weight: 233
url: /fr/net/mail-merge/
keywords:
- Publipostage
- personnalisation de présentation
- modèle de présentation
- espaces réservés de texte
- source de données
- CSV
- Excel
- XLSX
- JSON
- XML
- fusion de données
- générer des présentations
- .NET
- C#
- Aspose.Slides
description: "Apprenez à utiliser le publipostage dans Aspose.Slides pour .NET afin de remplir des modèles de présentation avec des données et de générer des présentations PowerPoint personnalisées à partir de sources CSV, Excel, JSON et XML."
---
## **Publipostage dans les présentations PowerPoint**

Aspose.Slides for .NET vous permet de générer automatiquement des présentations PowerPoint en utilisant un modèle et une source de données. Le publipostage remplit les espaces réservés du modèle avec les données et crée soit une présentation unique contenant des diapositives de modèle répétées pour chaque jeu de données, soit une présentation séparée pour chaque jeu de données.

Cette fonctionnalité est utile pour générer des catalogues de produits, des présentations personnalisées, des rapports, des certificats, des propositions, des listes de prix et d’autres documents dont la structure de la présentation reste identique tandis que le contenu varie.

![Publipostage : avant et après](mail-merge-before-after.png)


## **Fonctionnement du publipostage**

Le publipostage utilise une présentation PowerPoint comme modèle et remplace les espaces réservés par les valeurs d’une source de données.

![Flux de travail du publipostage](mail-merge-workflow.png)

Un espace réservé est un nom de champ entouré de doubles accolades, tel que `{{title}}` ou `{{price}}`. Les espaces réservés peuvent être placés dans le texte des formes, des cellules de tableau, des formes groupées et des notes du présentateur.

Par exemple, une diapositive modèle peut contenir le texte suivant :

- `Produit : {{title}}`
- `Prix : {{price}}`
- `Description : {{description}}`

Lorsque la source de données contient les valeurs suivantes :

| Champ | Valeur |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

Le publipostage remplace les espaces réservés par les valeurs correspondantes, produisant une diapositive avec les informations réelles du produit.

Les noms de champ ne sont pas sensibles à la casse, ainsi `{{title}}` et `{{Title}}` font référence au même champ.

Les règles suivantes s’appliquent lors du remplacement des espaces réservés :

- Les espaces réservés sont remplacés sur les diapositives, y compris les formes groupées et les cellules de tableau, ainsi que dans les notes du présentateur.
- Les espaces réservés sur les diapositives maîtres et les diapositives de mise en page ne sont pas remplacés.
- Un espace réservé dont le champ est absent du jeu de données reste inchangé.
- Une valeur de champ vide remplace son espace réservé par une chaîne vide.
- Le texte inséré hérite du formatage du premier caractère de l’espace réservé.
- Les valeurs ne doivent pas contenir de texte d’espace réservé, car le texte inséré pourrait être traité à nouveau et remplacé par un autre champ.

La présentation modèle originale n’est pas modifiée pendant l’opération de fusion et doit contenir au moins une diapositive.

## **Sources de données prises en charge**

Le publipostage prend en charge deux manières d’alimenter les données :

- Créer une source de données programmatiquement en utilisant `IMailMergeDataSource`.
- Lire les données à partir d’un fichier ou d’un flux CSV, XLSX, JSON ou XML.

Le format des données est détecté à partir de son contenu, pas à partir de l’extension du fichier. Les flux qui ne supportent pas la recherche sont également supportés.

La source de données doit contenir au moins un jeu de données. Chaque jeu de données représente une copie du modèle à remplir avec ses valeurs.

Si le contenu des données ne peut pas être reconnu comme un format pris en charge, `NotSupportedException` est levée. Si le contenu est reconnu mais ne respecte pas les exigences du format, `InvalidDataException` est levée. Le message d’exception indique l’emplacement de l’erreur dans les données.

### **JSON**

La source de données JSON doit avoir un objet racine contenant un tableau `sets`. Chaque élément du tableau représente un jeu de données et doit contenir un tableau `fields`. Chaque champ doit avoir une chaîne `name` et une chaîne `value`.

La propriété optionnelle `version` doit être `"1.0"` et la propriété optionnelle `type` d’un champ doit être `"text"`. Les noms de propriétés sont sensibles à la casse. Les propriétés inconnues sont ignorées.

Les données JSON sont lues en UTF-8, ou en UTF-16 lorsqu’elles commencent par un marqueur d’ordre d’octets (BOM).

L’exemple suivant contient deux jeux de données :

```json
{
  "version": "1.0",
  "sets": [
    {
      "fields": [
        { "name": "title", "value": "Laptop X1" },
        { "name": "price", "value": "$999" }
      ]
    },
    {
      "fields": [
        { "name": "title", "value": "Tablet S2" },
        { "name": "price", "value": "$499" }
      ]
    }
  ]
}
```

### **XML**

La source de données XML doit avoir un élément racine `template` contenant l’élément `sets`. Chaque élément `set` contient des éléments `field`, et chaque champ doit contenir des éléments `name` et `value`.

Un élément `value` vide est traité comme une chaîne vide. Les noms d’éléments sont sensibles à la casse. Les éléments inconnus et les commentaires sont ignorés. L’encodage est déterminé par la déclaration XML. Les définitions de type de document (DTD) ne sont pas autorisées.

```xml
<?xml version="1.0" encoding="utf-8"?>
<template>
  <sets>
    <set>
      <field>
        <name>title</name>
        <value>Laptop X1</value>
      </field>
      <field>
        <name>price</name>
        <value>$999</value>
      </field>
    </set>
    <set>
      <field>
        <name>title</name>
        <value>Tablet S2</value>
      </field>
      <field>
        <name>price</name>
        <value>$499</value>
      </field>
    </set>
  </sets>
</template>
```

### **CSV**

Les données CSV utilisent des points‑virgules comme séparateurs de valeur.

La première ligne contient les noms de champ et se termine au premier nom de champ vide. Chaque ligne suivante représente un jeu de données. Les données se terminent à la première ligne vide.

Les règles suivantes s’appliquent :

- Les valeurs manquantes à la fin d’une ligne sont traitées comme des chaînes vides.
- Les valeurs au‑delà des noms de champ définis sont ignorées.
- Une valeur contenant un point‑virgule, un guillemet ou un saut de ligne doit être entourée de guillemets.
- Les guillemets à l’intérieur d’une valeur entre guillemets doivent être doublés.
- Les données sont lues en UTF-8, ou en UTF-16 lorsqu’elles commencent par un BOM.

Exemple :

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

Les données XLSX sont lues à partir de la première feuille de calcul.

La feuille de calcul suit les mêmes règles que le CSV :

- La première ligne contient les noms de champ et se termine à la première cellule vide.
- Chaque ligne suivante représente un jeu de données.
- Les données se terminent à la première ligne vide.
- Les cellules vides sont traitées comme des chaînes vides.
- Les valeurs numériques sont converties en texte en utilisant la culture invariante.

## **Création d’une présentation unique**

La méthode `MergeToSinglePresentation` crée une présentation contenant une copie des diapositives du modèle pour chaque jeu de données. Chaque copie est remplie avec les données correspondantes.

L’ordre des jeux de données détermine l’ordre des groupes de diapositives dans la présentation résultante.

### **Fusion de données à partir d’un fichier**

L’exemple suivant charge un modèle et un fichier de données JSON, crée une présentation unique contenant les diapositives pour tous les jeux de données et enregistre le résultat.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, "products.json"))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

Les données peuvent également être lues à partir d’un flux. Le flux est lu à partir de sa position actuelle et n’est pas fermé par l’opération de publipostage.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xml"))
using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, data))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

### **Création d’une source de données dans le code**

Vous pouvez créer une source de données programmatiquement en utilisant `MailMergeDataSource` et `MailMergeDataSet`. Ajoutez un jeu de données pour chaque enregistrement et définissez ses champs à l’aide de la méthode `AddText`.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet laptop = source.AddDataSet();
laptop.AddText("title", "Laptop X1");
laptop.AddText("price", "$999");

IMailMergeDataSet tablet = source.AddDataSet();
tablet.AddText("title", "Tablet S2");
tablet.AddText("price", "$499");

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, source))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

Dans cet exemple, les diapositives du modèle sont répétées deux fois : une fois pour le portable et une fois pour la tablette. Les espaces réservés sont remplis avec les valeurs définies dans chaque jeu de données.

## **Création de plusieurs présentations**

Si vous avez besoin d’une présentation distincte pour chaque jeu de données, utilisez la méthode `MergeToMultiplePresentations`.

Cette méthode traite les jeux de données un par un, crée une présentation à partir du modèle, la remplit avec les données courantes et transmet la présentation résultante à un gestionnaire.

Le gestionnaire est invoqué une fois pour chaque jeu de données, dans l’ordre d’origine des données.

### **Enregistrement de chaque présentation**

L’exemple suivant lit les données d’un fichier CSV et enregistre chaque présentation générée sous forme de fichier séparé.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.csv",
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

La propriété `args.Index` fournit l’indice zéro‑based du jeu de données courant. Dans l’exemple, elle est utilisée pour générer des noms de fichiers séquentiels à partir de `product_1.pptx`.

Les données peuvent également être lues à partir d’un flux :

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xlsx"))
using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        data,
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

### **Utilisation des valeurs du jeu de données pour nommer les fichiers**

Le gestionnaire reçoit à la fois la présentation générée et des informations sur le jeu de données utilisé pour la créer. Vous pouvez utiliser les valeurs du jeu de données pour construire des noms de fichiers pertinents.

Par exemple, le code suivant enregistre chaque présentation en utilisant le titre du produit :

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string title = args.DataSet.GetText("title");
            string fileName = title != null
                ? title
                : "product_" + (args.Index + 1);

            presentation.Save(fileName + ".pptx", SaveFormat.Pptx);
        });
}
```

La propriété `DataSet` renvoie le jeu de données utilisé pour remplir la présentation courante. La méthode `GetText` récupère la valeur d’un champ spécifié, ou `null` si le champ n’existe pas.

Cela vous permet d’utiliser les valeurs des données pour nommer des fichiers, organiser la sortie ou appliquer un traitement supplémentaire dans le gestionnaire.

## **Gestion des présentations générées**

`MergeToMultiplePresentations` utilise le délégué `MailMergedPresentationHandler` pour traiter chaque présentation générée.

Le gestionnaire reçoit deux arguments :

- `presentation` — la présentation créée à partir du modèle et remplie avec le jeu de données actuel.
- `args` — informations sur la présentation générée, incluant l’indice du jeu de données et le jeu de données lui‑même.

La présentation générée appartient à l’opération de publipostage et est supprimée immédiatement après le retour du gestionnaire. Par conséquent, vous devez l’enregistrer ou copier les données requises à l’intérieur du gestionnaire. Ne conservez pas de référence après le retour du gestionnaire et ne la supprimez pas manuellement.

Le gestionnaire s’exécute sur le thread appelant, une présentation à la fois, dans l’ordre des jeux de données. Une seule présentation générée est conservée en mémoire à la fois, ce qui rend cette approche adaptée au traitement de grandes sources de données sans conserver toutes les présentations en mémoire simultanément.

Si le gestionnaire lève une exception, l’opération de publipostage s’arrête et l’exception est propagée à l’appelant telle quelle. Les présentations déjà traitées restent inchangées et les jeux de données restants ne sont pas traités.

L’exemple suivant enregistre les présentations générées dans un répertoire dédié :

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

string outputFolder = "output";
Directory.CreateDirectory(outputFolder);

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string path = Path.Combine(
                outputFolder,
                "product_" + (args.Index + 1) + ".pptx");

            presentation.Save(path, SaveFormat.Pptx);
        });
}
```

## **Travail avec les données du publipostage**

La classe `MailMergeDataSource` représente une collection ordonnée de jeux de données. Elle peut être utilisée pour créer des données en code, inspecter le nombre de jeux de données et accéder à des jeux de données individuels par indice.

### **Obtention du nombre de jeux de données**

La propriété `Count` renvoie le nombre de jeux de données dans la source.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **Accès à un jeu de données par indice**

La propriété `Item(int)` donne accès à un jeu de données à l’indice zéro‑based spécifié.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Cet exemple récupère le titre du deuxième jeu de données.

### **Ajout de champs texte**

La méthode `AddText` ajoute un champ texte nommé à un jeu de données. La valeur du champ remplace tous les espaces réservés correspondants dans le modèle.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Une valeur vide supprime l’espace réservé correspondant du texte résultant. Si le champ n’est pas ajouté au jeu de données, l’espace réservé reste inchangé.

### **Lecture des champs texte**

La méthode `GetText` récupère la valeur d’un champ par son nom. Les noms de champ ne sont pas sensibles à la casse.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Si le champ n’existe pas ou si le nom de champ spécifié est `null`, `GetText` renvoie `null`.

## **Résumé**

Le publipostage dans Aspose.Slides for .NET offre un moyen pratique de générer des présentations basées sur des données à partir d’un modèle réutilisable.

Vous pouvez l’utiliser pour :

- Remplir les modèles de présentation avec les valeurs provenant des sources de données.
- Générer une présentation unique contenant des diapositives modèle répétées pour plusieurs jeux de données.
- Créer une présentation distincte pour chaque jeu de données.
- Lire les données à partir de fichiers ou flux CSV, XLSX, JSON et XML.
- Construire des sources de données directement dans le code.
- Traiter et enregistrer les présentations générées séquentiellement à l’aide d’un gestionnaire.

En combinant des modèles réutilisables avec des données structurées, vous pouvez automatiser la création d’un grand nombre de présentations tout en conservant séparés la conception du modèle et la logique de traitement des données.

## **Questions fréquentes**

**Puis-je utiliser le même espace réservé plusieurs fois dans un modèle ?**

Oui. Chaque occurrence d’un espace réservé avec un nom de champ correspondant est remplacée par la valeur correspondante du jeu de données actuel.

**Les noms de champ sont-ils sensibles à la casse ?**

Non. Les noms d’espaces réservés et les noms de champ de données ne sont pas sensibles à la casse. Par exemple, `{{title}}`, `{{Title}}` et `{{TITLE}}` font référence au même champ.

**Que se passe-t-il si un champ est absent d’un jeu de données ?**

Si le jeu de données ne contient pas un champ référencé par un espace réservé, cet espace réservé reste inchangé dans la présentation générée.

**Que se passe-t-il si un champ a une valeur vide ?**

Une valeur de champ vide remplace l’espace réservé par une chaîne vide. Le texte de l’espace réservé est supprimé, laissant aucun texte à sa place.

**Puis‑je conserver le formatage d’un espace réservé lors de son remplacement ?**

Le texte de remplacement hérite du formatage du premier caractère de l’espace réservé. Appliquez le formatage souhaité au texte de l’espace réservé dans le modèle avant d’effectuer la fusion.

**Le publipostage remplace‑t‑il les espaces réservés sur les diapositives maîtres ou de mise en page ?**

Non. Le publipostage remplace les espaces réservés dans le contenu pris en charge des diapositives de la présentation, y compris les formes, les formes groupées, les cellules de tableau et les notes du présentateur. Les espaces réservés sur les diapositives maîtres et de mise en page ne sont pas remplacés.

**La présentation modèle est‑elle modifiée pendant la fusion ?**

Non. Le modèle original n’est pas modifié par l’opération de fusion. Vous pouvez le réutiliser pour générer des présentations à partir de la même ou d’autres sources de données.

**Puis‑je générer une présentation distincte pour chaque jeu de données ?**

Oui. Utilisez `MergeToMultiplePresentations` et enregistrez chaque présentation générée dans le gestionnaire. Le gestionnaire est appelé séquentiellement pour chaque jeu de données.

**Puis‑je combiner tous les jeux de données en une seule présentation ?**

Oui. Utilisez `MergeToSinglePresentation`. Elle crée une présentation unique contenant une copie des diapositives du modèle pour chaque jeu de données, dans l’ordre de la source de données.

**Puis‑je utiliser une source de données sans la sauvegarder dans un fichier ?**

Oui. Vous pouvez créer un `MailMergeDataSource` en code, ajouter des jeux de données et peupler les champs avec `AddText`. Cela est utile lorsque vos données sont déjà disponibles dans votre application.

**Le publipostage détecte‑t‑il le format des données à partir de l’extension du fichier ?**

Non. Le format des données est détecté à partir du contenu, de sorte qu’une source de données prise en charge n’a pas besoin d’utiliser une extension de fichier particulière.

**Puis‑je lire des données à partir d’un flux qui ne supporte pas la recherche ?**

Oui. Le publipostage prend en charge les flux non recherchables.

**Que se passe‑t‑il si la source de données est vide ou ne contient aucun jeu de données ?**

La source de données doit contenir au moins un jeu de données. Assurez‑vous qu’elle inclut au moins un enregistrement avant de démarrer la fusion.

**Que se passe‑t‑il si la source de données a un format invalide ?**

Si le contenu n’est pas reconnu comme l’un des formats de données pris en charge, `NotSupportedException` est levée. S’il est reconnu mais mal formé, `InvalidDataException` est levée. Le message d’exception indique l’emplacement de l’erreur.

**Puis‑je utiliser la présentation générée après le retour du gestionnaire ?**

La présentation transmise au gestionnaire `MergeToMultiplePresentations` appartient au publipostage et est supprimée après le retour du gestionnaire. Enregistrez‑la ou copiez le contenu nécessaire à l’intérieur du gestionnaire, et ne conservez pas ou ne supprimez pas vous‑même cette présentation.

**Le gestionnaire est‑il appelé en parallèle ?**

Non. Les présentations générées sont traitées séquentiellement, sur le thread de l’appelant. Une seule présentation générée est maintenue en mémoire à la fois par cette opération.

**Que se passe‑t‑il si une exception se produit à l’intérieur du gestionnaire ?**

L’opération de fusion s’arrête, et l’exception est propagée à l’appelant sans modification. Les présentations déjà traitées ne sont pas affectées, et les jeux de données restants ne sont pas traités.

**Puis‑je utiliser les valeurs des champs pour générer les noms de fichiers de sortie ?**

Oui. Le gestionnaire fournit le jeu de données actuel via ses arguments. Utilisez `GetText` pour récupérer les champs et construire un nom de fichier pour chaque présentation générée. Assurez‑vous que les valeurs sont valides pour les noms de fichiers dans votre environnement cible.