---
title: Récupérer et mettre à jour les informations de présentation en Java
linktitle: Informations de présentation
type: docs
weight: 30
url: /fr/java/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir les propriétés
- lire les propriétés
- changer les propriétés
- modifier les propriétés
- mettre à jour les propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument en utilisant Java pour obtenir des informations plus rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Cet article montre comment inspecter les informations de présentation dans Aspose.Slides. Il explique comment déterminer le format actuel d’une présentation sans charger le fichier complet, lire ses propriétés de document, et mettre à jour ces propriétés si nécessaire.

Les exemples sont basés sur les API [PresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationinfo/) et [DocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/documentproperties/) et illustrent les opérations typiques de manipulation des métadonnées de présentation.

## **Vérifier le format d'une présentation**

Avant de travailler sur une présentation, vous pouvez souhaiter connaître le format (PPT, PPTX, ODP, etc.) dans lequel la présentation se trouve actuellement.

Vous pouvez vérifier le format d’une présentation sans la charger. Voir le code Java suivant :

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Obtenir les propriétés de la présentation**

Ce code Java montre comment obtenir les propriétés de la présentation (informations sur la présentation) :

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Vous pouvez vouloir consulter les [propriétés de la classe DocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Mettre à jour les propriétés de la présentation**

Aspose.Slides fournit la méthode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) qui permet de modifier les propriétés de la présentation.

Supposons que nous disposions d’une présentation PowerPoint avec les propriétés de document affichées ci‑dessous.

![Propriétés de document d'origine de la présentation PowerPoint](input_properties.png)

Cet exemple de code montre comment modifier certaines propriétés de la présentation :

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Les résultats de la modification des propriétés de document sont affichés ci‑dessous.

![Propriétés de document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir plus d’informations sur une présentation et ses attributs de sécurité, vous trouverez peut‑être ces liens utiles :

- [Protéger les présentations par mot de passe](/slides/fr/java/password-protected-presentation/)
- [Protéger les présentations en écriture](/slides/fr/java/write-protected-presentation/)

## **FAQ**

**Comment puis‑je vérifier si les polices sont incorporées et lesquelles ?**  
Recherchez les [informations sur les polices incorporées](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) au niveau de la présentation, puis comparez ces entrées avec l’ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsmanager/#getFonts--) afin d’identifier les polices essentielles au rendu.

**Comment puis‑je rapidement déterminer si le fichier contient des diapositives masquées et combien ?**  
Parcourez la [collection de diapositives](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidecollection/) et inspectez le [drapeau de visibilité](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/#getHidden--) de chaque diapositive.

**Puis‑je détecter si une taille de diapositive et une orientation personnalisées sont utilisées, et si elles diffèrent des valeurs par défaut ?**  
Oui. Comparez la [taille de diapositive](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSlideSize--) et l’orientation actuelles avec les préréglages standards ; cela aide à anticiper le comportement lors de l’impression et de l’exportation.

**Existe‑t‑il un moyen rapide de vérifier si les graphiques font référence à des sources de données externes ?**  
Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chart/), vérifiez leur [source de données](https://reference.aspose.com/slides/fr/java/com.aspose.slides/chartdata/#getDataSourceType--), et notez si les données sont internes ou basées sur un lien, y compris les liens cassés.

**Comment puis‑je évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l’exportation PDF ?**  
Pour chaque diapositive, comptez le nombre d’objets et recherchez les images volumineuses, la transparence, les ombres, les animations et les éléments multimédia ; attribuez un score de complexité approximatif afin d’identifier les points potentiels de ralentissement de performance.