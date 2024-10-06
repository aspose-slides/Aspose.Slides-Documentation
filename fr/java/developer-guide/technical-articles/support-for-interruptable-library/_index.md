---
title: Support Pour la Bibliothèque Interruptible
type: docs
weight: 120
url: /java/support-for-interruptable-library/
---

## **Bibliothèque Interruptible**
Maintenant, dans Aspose.Slides, la structure InterruptionToken et la classe InterruptionTokenSource ont été ajoutées. Ces types prennent en charge l'interruption des tâches de longue durée, telles que la désérialisation, la sérialisation ou le rendu. InterruptionTokenSource représente la source du jeton ou plusieurs jetons passés à **ILoadOptions.InterruptionToken**. Lorsque ILoadOptions.InterruptionToken est défini et que cette instance de LoadOptions est passée au constructeur Presentation, toute tâche de longue durée liée à cette Présentation sera interrompue lorsque la méthode InterruptionTokenSource.Interrupt sera invoquée.

L'extrait de code ci-dessous démontre l'interruption d'une tâche en cours.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}