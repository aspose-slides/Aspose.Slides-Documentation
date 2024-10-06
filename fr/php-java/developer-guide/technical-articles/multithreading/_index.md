---
title: Multithreading dans Aspose.Slides
type: docs
weight: 310
url: /php-java/multithreading/
keywords:
- PowerPoint
- présentation
- multithreading
- travail parallèle
- convertir des diapositives
- diapositives en images
- PHP
- Java
- Aspose.Slides pour PHP via Java
---

## **Introduction**

Bien que le travail parallèle avec des présentations soit possible (en plus du parsing/chargement/clonage) et que tout se passe généralement bien (la plupart du temps), il y a une petite chance que vous obteniez des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous vous recommandons fortement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) dans un environnement multithreading car cela pourrait entraîner des erreurs ou des échecs imprévisibles qui ne sont pas facilement détectés.

Il n'est **pas** sécuritaire de charger, enregistrer et/ou cloner une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) dans plusieurs threads. De telles opérations ne sont **pas** supportées. Si vous devez effectuer de telles tâches, vous devez paralléliser les opérations en utilisant plusieurs processus à thread unique—et chacun de ces processus devrait utiliser sa propre instance de présentation.

Nous ne garantissons pas le multithreading en PHP lors de l'utilisation d'extensions. Si vous les utilisez, c'est à vos propres risques.