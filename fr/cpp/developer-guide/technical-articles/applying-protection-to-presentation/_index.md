---
title: Empêcher les modifications de la présentation avec les verrous de forme
linktitle: Empêcher les modifications de la présentation
type: docs
weight: 10
url: /fr/cpp/applying-protection-to-presentation/
keywords:
- empêcher les modifications
- protéger contre la modification
- verrouiller la forme
- verrouiller la position
- verrouiller la sélection
- verrouiller la taille
- verrouiller le groupement
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for C++ verrouille ou déverrouille les formes dans les fichiers PPT, PPTX et ODP, sécurisant les présentations tout en permettant des modifications contrôlées et une livraison plus rapide."
---

## **Contexte**

Une utilisation courante d’Aspose.Slides consiste à créer, mettre à jour et enregistrer des présentations Microsoft PowerPoint (PPTX) dans le cadre d’un flux de travail automatisé. Les utilisateurs d’applications qui emploient Aspose.Slides de cette manière ont accès aux présentations générées, ce qui rend la protection contre la modification une préoccupation fréquente. Il est important que les présentations générées automatiquement conservent leur mise en forme et leur contenu d’origine.

Cet article explique comment les présentations et les diapositives sont structurées et comment Aspose.Slides for C++ peut appliquer une protection à une présentation et la supprimer ultérieurement. Il fournit aux développeurs un moyen de contrôler l’utilisation des présentations générées par leurs applications.

## **Composition d’une diapositive**

Une diapositive de présentation est composée d’éléments tels que des formes auto‑générées, des tableaux, des objets OLE, des formes groupées, des cadres d’image, des cadres vidéo, des connecteurs et d’autres éléments utilisés pour créer une présentation. Dans Aspose.Slides for C++, chaque élément d’une diapositive est représenté par un objet qui implémente l’interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) ou hérite d’une classe qui le fait.

La structure du PPTX est complexe, de sorte qu’à la différence du PPT, où un verrou générique peut être utilisé pour tous les types de formes, différents types de formes nécessitent des verrous différents. L’interface [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) est la classe de verrouillage générique pour le PPTX. Les types de verrous suivants sont pris en charge dans Aspose.Slides for C++ pour le PPTX :

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) verrouille les formes auto‑générées.  
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) verrouille les formes de connecteur.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) verrouille les objets graphiques.  
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) verrouille les formes groupées.  
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) verrouille les cadres d’image.   

Toute action effectuée sur tous les objets de forme dans un objet [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) est appliquée à l’ensemble de la présentation.

## **Appliquer et supprimer la protection**

L’application d’une protection garantit qu’une présentation ne peut pas être modifiée. C’est une technique utile pour protéger le contenu de la présentation.

### **Appliquer la protection aux formes PPTX**

Aspose.Slides for C++ fournit l’interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) pour travailler avec les formes d’une diapositive.

Comme indiqué précédemment, chaque classe de forme possède une classe de verrouillage associée pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous assurent que les formes ne peuvent pas être sélectionnées (par clics de souris ou autres méthodes de sélection) et qu’elles ne peuvent pas être déplacées ou redimensionnées.

L’exemple de code qui suit applique la protection à tous les types de formes dans une présentation.
```cpp
// Instancier la classe Presentation qui représente un fichier PPTX.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Parcourir toutes les diapositives de la présentation.
for (auto&& slide : presentation->get_Slides())	{

	// Parcourir toutes les formes de la diapositive.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Conversion du type de la forme en autoshape et récupération de son verrou de forme.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Conversion du type de la forme en forme groupée et récupération de son verrou de forme.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Conversion du type de la forme en connecteur et récupération de son verrou de forme.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Conversion du type de la forme en cadre d'image et récupération de son verrou de forme.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// Enregistrement du fichier de présentation.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


### **Supprimer la protection**

Pour déverrouiller une forme, définissez la valeur du verrou appliqué sur `false`. L’exemple de code suivant montre comment déverrouiller les formes dans une présentation verrouillée.
```cpp
// Instancier la classe Presentation qui représente un fichier PPTX.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// Parcourir toutes les diapositives de la présentation.
for (auto&& slide : presentation->get_Slides())	{

	// Parcourir toutes les formes de la diapositive.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// Conversion de type de la forme en autoshape et obtention de son verrou de forme.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// Conversion de type de la forme en forme groupée et obtention de son verrou de forme.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// Conversion de type de la forme en connecteur et obtention de son verrou de forme.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// Conversion de type de la forme en cadre d'image et obtention de son verrou de forme.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// Enregistrement du fichier de présentation.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Conclusion**

Aspose.Slides propose plusieurs options pour protéger les formes d’une présentation. Vous pouvez verrouiller une forme individuelle ou parcourir toutes les formes d’une présentation et verrouiller chacune d’elles afin de sécuriser efficacement l’ensemble du fichier. Vous pouvez supprimer la protection en définissant la valeur du verrou sur `false`.

## **FAQ**

**Puis‑je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous limitent la modification des objets à l’intérieur du fichier, tandis que la [protection par mot de passe](/slides/fr/cpp/password-protected-presentation/) contrôle l’accès à l’ouverture et/ou à l’enregistrement des modifications. Ces mécanismes se complètent et fonctionnent ensemble.

**Puis‑je restreindre la modification de diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez des verrous aux formes des diapositives sélectionnées ; les diapositives restantes resteront modifiables.

**Les verrous de forme s’appliquent‑ils aux objets groupés et aux connecteurs ?**

Oui. Des types de verrous dédiés sont pris en charge pour les groupes, les connecteurs, les objets graphiques et les autres types de formes.