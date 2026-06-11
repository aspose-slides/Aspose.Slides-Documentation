---
title: Deklaracja
type: docs
weight: 60
url: /pl/php-java/declaration/
keywords:
- deklaracja
- komponenty
- uprawnienie Full Trust
- ustawienia rejestru
- pliki systemowe
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się o wymaganiach zaufania, uprawnieniach i ograniczeniach hostingu Aspose.Slides dla PHP, abyś mógł bezpiecznie wdrażać aplikacje przetwarzające pliki PPT, PPTX i ODP na serwerach."
---
{{% alert color="primary" %}} 

Wszystkie komponenty Aspose Java wymagają zestawu uprawnień Full Trust. Powodem jest to, że komponenty Aspose Java muszą mieć dostęp do ustawień rejestru, systemowych plików poza wirtualnym katalogiem w celu wykonywania niektórych operacji, takich jak parsowanie czcionek itp. Ponadto komponenty Aspose Java opierają się na podstawowych klasach systemowych Java, które również w wielu przypadkach wymagają zestawu uprawnień Full Trust. 

{{% /alert %}} 

Dostawcy usług internetowych (ISP) hostujący wiele aplikacji od różnych firm zazwyczaj wymuszają poziom zabezpieczeń Medium Trust: 

- OleDbPermission nie jest dostępny. Oznacza to, że nie możesz używać zarządzanego dostawcy danych ADO.NET OLE DB do dostępu do baz danych.
- EventLogPermission nie jest dostępny. Oznacza to, że nie możesz uzyskać dostępu do dziennika zdarzeń Windows.
- ReflectionPermission nie jest dostępny. Oznacza to, że nie możesz używać refleksji.
- RegistryPermission nie jest dostępny. Oznacza to, że nie możesz uzyskać dostępu do rejestru.
- WebPermission jest ograniczony. Oznacza to, że Twoja aplikacja może komunikować się tylko z adresem lub zakresem adresów, które zdefiniujesz w elemencie <trust>.
- FileIOPermission jest ograniczony. Oznacza to, że możesz uzyskać dostęp tylko do plików w hierarchii wirtualnego katalogu Twojej aplikacji.

{{% alert color="primary" %}} 

Z powodu wyżej wymienionych powodów komponenty Aspose Java nie mogą być używane na serwerach przyznających zestaw uprawnień inny niż Full Trust. 

{{% /alert %}}