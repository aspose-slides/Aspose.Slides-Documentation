---
title: Bekannte Probleme in Aspose.Slides für PHP über Java 14.4.0
type: docs
weight: 30
url: /de/php-java/known-issues-in-aspose-slides-for-java-14-4-0/
---

{{% alert color="primary" %}} 

Aspose.Slides für PHP über Java 14.4.0 bietet neue Entscheidungen für die Verarbeitung von PowerPoint-Dokumenten. Es gibt einige Einschränkungen und bekannte Probleme, die in kommenden Versionen behoben werden:

- Einige Formen haben eine falsche Geometrie in serialisierten PPT-Dokumenten (Bogen, Kreis-Pfeil, Sprechblasen).
- Nicht alle PPTX-Textformatierungsfunktionen werden in der PPT-Serialisierung unterstützt (Tabulatoren, Einrückungen und Absatzformatierungsbeschränkungen).
- Informationen über die Textsprache und die Rechtschreibereinstellungen sind in serialized PPT-Dokumenten nicht vorhanden.
- Nicht alle PPTX-Theme-Funktionen werden in der PPT-Serialisierung unterstützt (nur Serialisierung von Füllformaten, Linienformaten und Schriftarten).
- Es gibt bekannte Probleme bei der OLE/ActiveX PPT-Serialisierung zu PPT.
- WordArt-Serialisierung und -Rendering werden nicht unterstützt.

{{% /alert %}}