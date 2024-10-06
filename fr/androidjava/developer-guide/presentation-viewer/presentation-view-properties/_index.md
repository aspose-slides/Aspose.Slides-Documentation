---
title: Propriétés de la vue normale
type: docs
url: /androidjava/presentation-view-properties/
---

{{% alert color="primary" %}} 

La vue normale se compose de trois régions de contenu : la diapositive elle-même, une région de contenu latérale et une région de contenu inférieure. Propriétés relatives au positionnement des différentes régions de contenu. Cette information permet à l'application de sauvegarder son état de vue dans le fichier, afin que lorsqu'elle est rouverte, la vue soit dans le même état que lorsque la présentation a été enregistrée pour la dernière fois.

La méthode [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) a été ajoutée pour fournir un accès aux propriétés de la vue normale de la présentation. 

Les interfaces [**INormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties) et ses descendants, l'énumération [**SplitterBarStateType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType) ont été ajoutés.

{{% /alert %}} 


## **À propos de INormalViewProperties** #
Représente les propriétés de la vue normale.

Les méthodes [**getShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) et [**setShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) spécifient si l'application doit afficher des icônes lors de l'affichage du contenu d'une structure dans l'une des régions de contenu du mode de vue normale.

Les méthodes [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) et [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) spécifient si le séparateur vertical doit s'enclencher dans un état réduit lorsque la région latérale est suffisamment petite.

La propriété [**getPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) et [**setPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) spécifient si l'utilisateur préfère voir une seule région de contenu en plein écran plutôt que la vue normale standard avec trois régions de contenu. Si activé, l'application peut choisir d'afficher une des régions de contenu dans l'ensemble de la fenêtre.

Les méthodes [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) et [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) spécifient l'état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la région de contenu située sous la diapositive, la barre de séparation verticale sépare la diapositive de la région de contenu latérale. Les valeurs possibles sont : [**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) et [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Les méthodes [**getRestoredLeft**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) et [**getRestoredTop**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) spécifient la taille de la région de diapositive supérieure ou latérale de la vue normale, lorsque la valeur [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) est appliquée pour [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) et [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) en conséquence.


## **À propos de la restauration de INormalViewProperties** 
Spécifie la taille de la région de diapositive (largeur lorsqu'elle est un enfant de [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), hauteur lorsqu'elle est un enfant de [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) de la vue normale, lorsque la région a une taille restaurée variable (ni minimisée, ni maximisée). 

La méthode [**getDimensionSize**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) spécifie la taille de la région de diapositive (largeur lorsqu'elle est un enfant de restoredTop, hauteur lorsqu'elle est un enfant de restoredLeft).

La méthode [**getAutoAdjust**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) spécifie si la taille de la région de contenu latéral doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l'application.

Un exemple est donné ci-dessous pour montrer comment accéder aux propriétés [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) pour une présentation.

```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Restaurer les propriétés de vue de la présentation
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Définir la valeur de zoom par défaut**
{{% alert color="primary" %}} 

Aspose.Slides pour Android via Java prend désormais en charge la définition de la valeur de zoom par défaut pour la présentation afin que, lorsque la présentation est ouverte, le zoom soit déjà défini. Cela peut être fait en définissant les [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) d'une présentation. [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) peuvent être définis par programme. Dans ce sujet, nous allons voir avec un exemple comment définir les [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) dans [Aspose.Slides](/slides/).

{{% /alert %}} 

Pour définir les propriétés de vue. Veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Définissez les [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Écrivez la présentation en tant que fichier [PPTX ](https://docs.fileformat.com/presentation/pptx/).
   Dans l'exemple donné ci-dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue des notes.

```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation presentation = new Presentation();
try {
    // Définir les View Properties de la présentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valeur de zoom en pourcentage pour la vue de diapositive
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valeur de zoom en pourcentage pour la vue des notes 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```