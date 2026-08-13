---
title: Deklaracja
type: docs
weight: 60
url: /pl/java/declaration/
keywords:
- deklaracja
- komponenty
- uprawnienie pełnego zaufania
- ustawienia rejestru
- pliki systemowe
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Poznaj wymagania dotyczące zaufania, uprawnień i ograniczeń hostingu Aspose.Slides dla języka Java, aby bezpiecznie wdrażać aplikacje przetwarzające pliki PPT, PPTX i ODP na serwerach."
---
{{% alert color="info" %}} 

Wszystkie komponenty Aspose Java wymagają zestawu uprawnień Full Trust. Powodem jest to, że komponenty Aspose Java muszą uzyskać dostęp do ustawień rejestru, plików systemowych poza wirtualnym katalogiem w celu wykonywania niektórych operacji, takich jak parsowanie czcionek itp. Co więcej, komponenty Aspose Java opierają się na podstawowych klasach systemowych Javy, które również w wielu przypadkach wymagają zestawu uprawnień Full Trust. 

{{% /alert %}} 

Dostawcy usług internetowych hostujący wiele aplikacji od różnych firm zazwyczaj wymuszają poziom bezpieczeństwa Medium Trust: 

- OleDbPermission nie jest dostępny. Oznacza to, że nie możesz używać zarządzanego dostawcy danych OLE DB ADO.NET do dostępu do baz danych.
- EventLogPermission nie jest dostępny. Oznacza to, że nie możesz uzyskać dostępu do dziennika zdarzeń Windows.
- ReflectionPermission nie jest dostępny. Oznacza to, że nie możesz używać refleksji.
- RegistryPermission nie jest dostępny. Oznacza to, że nie możesz uzyskać dostępu do rejestru.
- WebPermission jest ograniczony. Oznacza to, że Twoja aplikacja może komunikować się tylko z adresem lub zakresem adresów, które zdefiniujesz w elemencie <trust>.
- FileIOPermission jest ograniczony. Oznacza to, że możesz uzyskać dostęp tylko do plików w hierarchii wirtualnego katalogu Twojej aplikacji.

{{% alert color="info" %}} 

Ze względu na powyższe przyczyny, komponenty Aspose Java nie mogą być używane na serwerach przyznających zestaw uprawnień inny niż Full Trust. 

{{% /alert %}}