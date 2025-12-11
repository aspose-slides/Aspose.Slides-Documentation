---
title: Supprimer des diapositives des présentations en C++
linktitle: Supprimer une diapositive
type: docs
weight: 30
url: /fr/cpp/remove-slide-from-presentation/
keywords:
- supprimer une diapositive
- supprimer une diapositive
- supprimer une diapositive inutilisée
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Supprimez facilement les diapositives des présentations PowerPoint et OpenDocument avec Aspose.Slides pour C++. Obtenez des exemples de code clairs et améliorez votre flux de travail."
---

Si une diapositive (ou son contenu) devient redondante, vous pouvez la supprimer. Aspose.Slides fournit la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) qui encapsule [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/), qui est un référentiel de toutes les diapositives d’une présentation. En utilisant des pointeurs (référence ou indice) pour un objet [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) connu, vous pouvez spécifier la diapositive que vous souhaitez supprimer. 

## **Supprimer une diapositive par référence**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenez une référence de la diapositive que vous souhaitez supprimer via son ID ou son indice.
1. Supprimez la diapositive référencée de la présentation.
1. Enregistrez la présentation modifiée. 

Ce code C++ vous montre comment supprimer une diapositive via sa référence :
```c++
	// Le chemin du répertoire des documents
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Crée une instance d'un objet Presentation qui représente un fichier de présentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Accède à une diapositive via son index dans la collection de diapositives
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Supprime une diapositive via sa référence
	pres->get_Slides()->Remove(slide);

	// Enregistre la présentation modifiée
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```



## **Supprimer une diapositive par indice**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Supprimez la diapositive de la présentation en utilisant sa position d'indice.
1. Enregistrez la présentation modifiée. 

Ce code C++ vous montre comment supprimer une diapositive via son indice :
```c++
	// Le chemin du répertoire des documents
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Instancie un objet Presentation qui représente un fichier de présentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Supprime une diapositive via son indice
	pres->get_Slides()->RemoveAt(0);

	// Enregistre la présentation modifiée
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Supprimer les diapositives de mise en page inutilisées**

Aspose.Slides fournit la méthode [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (de la classe [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) afin de vous permettre de supprimer les mises en page indésirables et inutilisées. Ce code C++ vous montre comment supprimer une diapositive de mise en page d’une présentation PowerPoint :
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **Supprimer les diapositives maîtres inutilisées**

Aspose.Slides fournit la méthode [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la classe [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) afin de vous permettre de supprimer les maîtres indésirables et inutilisés. Ce code C++ vous montre comment supprimer une diapositive maître d’une présentation PowerPoint :
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Que se passe-t-il avec les indices de diapositives après la suppression d’une diapositive ?**

Après la suppression, la [collection](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) se réindexe : chaque diapositive suivante se décale d’une position vers la gauche, de sorte que les numéros d’indices précédents ne sont plus valides. Si vous avez besoin d’une référence stable, utilisez l’ID persistant de chaque diapositive plutôt que son indice.

**L’ID d’une diapositive est‑il différent de son indice, et change‑t‑il lorsque les diapositives voisines sont supprimées ?**

Oui. L’indice correspond à la position de la diapositive et changera lorsque des diapositives seront ajoutées ou supprimées. L’ID de la diapositive est un identifiant persistant et ne change pas lorsque d’autres diapositives sont supprimées.

**Comment la suppression d’une diapositive affecte‑t‑elle les sections de diapositives ?**

Si la diapositive faisait partie d’une section, cette section contiendra simplement une diapositive de moins. La structure de la section reste intacte ; si une section devient vide, vous pouvez [supprimer ou réorganiser les sections](/slides/fr/cpp/slide-section/) selon les besoins.

**Que se passe‑t‑il avec les notes et les commentaires attachés à une diapositive lorsqu’elle est supprimée ?**

[Notes](/slides/fr/cpp/presentation-notes/) et [comments](/slides/fr/cpp/presentation-comments/) sont liés à cette diapositive spécifique et sont supprimés avec elle. Le contenu des autres diapositives reste intact.

**En quoi la suppression de diapositives diffère‑t‑elle du nettoyage des mises en page/maîtres inutilisés ?**

La suppression retire des diapositives normales spécifiques du jeu. Le nettoyage des mises en page/maîtres inutilisés supprime les diapositives de mise en page ou maîtres qui ne sont référencées par aucune diapositive, réduisant ainsi la taille du fichier sans modifier le contenu des diapositives restantes. Ces actions sont complémentaires : généralement, on supprime d’abord, puis on nettoie.