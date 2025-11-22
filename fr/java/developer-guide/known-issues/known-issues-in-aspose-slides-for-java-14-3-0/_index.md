---
title: Problèmes connus dans Aspose.Slides for Java 14.3.0
type: docs
weight: 20
url: /fr/java/known-issues-in-aspose-slides-for-java-14-3-0/
keywords:
- problème connu
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Examinez les problèmes connus dans Aspose.Slides for Java 14.3.0 pour garantir un travail précis avec les fichiers PowerPoint et OpenDocument et éviter les mauvaises surprises dans vos présentations."
---

Aspose.Slides for Java 14.3.0 (14.4.0) fournit une implémentation complètement nouvelle du traitement PPT. Il y a de nombreuses améliorations, une conversion partielle PPTX vers PPT. Mais certaines fonctionnalites ne sont pas encore implementees :

- Certaines formes ont une geometrie incorrecte dans les documents PPT serializés (Call outs)
- Toutes les fonctionnalites de mise en forme du texte PPTX ne sont pas prises en charge lors de la serializétion PPT
- Les informations sur la langue du texte et les parametres d'orthographe ne sont pas presentes dans les documents PPT serializés
- Toutes les fonctionnalites des themes PPTX ne sont pas prises en charge lors de la serializétion PPT

**Il y a quelques differences comparees a Aspose.Slides for Java 8.6.0 :**

- Des problemes connus existent lors de la serializétion OLE/ActiveX PPT vers PPT

**Il y a quelques differences comparees a Aspose.Slides for .NET 14.3.0 :**

- Le support de l'impression de presentations n'est actuellement pas disponible dans Aspose.Slides for Java