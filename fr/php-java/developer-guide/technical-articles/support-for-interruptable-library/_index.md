---
title: Support pour la bibliothèque Interrompable
type: docs
weight: 120
url: /php-java/support-for-interruptable-library/
---

## **Bibliothèque Interrompable**
Maintenant dans Aspose.Slides, la structure InterruptionToken et la classe InterruptionTokenSource ont été ajoutées. Ces types supportent l'interruption de tâches de longue durée, telles que la désérialisation, la sérialisation ou le rendu. InterruptionTokenSource représente la source du jeton ou des jetons multiples passés à **ILoadOptions.InterruptionToken**. Lorsque ILoadOptions.InterruptionToken est défini et que cette instance de LoadOptions est passée au constructeur Presentation, toute tâche de longue durée liée à cette présentation sera interrompue lorsque la méthode InterruptionTokenSource.Interrupt sera invoquée.

Le code ci-dessous démontre l'interruption d'une tâche en cours.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}