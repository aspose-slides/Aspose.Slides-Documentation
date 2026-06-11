---
title: Deklaracja
type: docs
weight: 60
url: /pl/java/declaration/
keywords:
- deklaracja
- komponenty
- uprawnienie Full Trust
- ustawienia rejestru
- pliki systemowe
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się o wymaganiach zaufania, uprawnieniach i ograniczeniach hostingu Aspose.Slides dla Javy, abyś mógł bezpiecznie wdrażać aplikacje przetwarzające pliki PPT, PPTX i ODP na serwerach."
---
{{% alert color="primary" %}} 

Wszystkie komponenty Aspose Java wymagają zestawu uprawnień Full Trust. Powodem jest to, że komponenty Aspose Java muszą mieć dostęp do ustawień rejestru, plików systemowych poza wirtualnym katalogiem w celu wykonywania niektórych operacji, takich jak parsowanie czcionek itp. Ponadto komponenty Aspose Java opierają się na podstawowych klasach systemu Java, które również w wielu przypadkach wymagają zestawu uprawnień Full Trust. 

{{% /alert %}} 

Dostawcy usług internetowych hostujący wiele aplikacji od różnych firm zazwyczaj wymuszają poziom bezpieczeństwa Medium Trust: 

- OleDbPermission nie jest dostępny. Oznacza to, że nie możesz używać zarządzanego dostawcy danych ADO.NET OLE DB do dostępu do baz danych.
- EventLogPermission nie jest dostępny. Oznacza to, że nie możesz uzyskać dostępu do dziennika zdarzeń systemu Windows.
- ReflectionPermission nie jest dostępny. Oznacza to, że nie możesz używać refleksji.
- RegistryPermission nie jest dostępny. Oznacza to, że nie możesz uzyskać dostępu do rejestru.
- WebPermission jest ograniczony. Oznacza to, że Twoja aplikacja może komunikować się tylko z adresem lub zakresem adresów określonym w elemencie <trust>.
- FileIOPermission jest ograniczony. Oznacza to, że możesz uzyskać dostęp tylko do plików w hierarchii wirtualnego katalogu Twojej aplikacji.

{{% alert color="primary" %}} 

Ze względu na powyższe przyczyny komponenty Aspose Java nie mogą być używane na serwerach przyznających zestaw uprawnień inny niż Full Trust. 

{{% /alert %}}