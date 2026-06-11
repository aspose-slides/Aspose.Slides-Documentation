---
title: Deklaracja
type: docs
weight: 110
url: /pl/net/declaration/
keywords:
- deklaracja
- komponenty
- uprawnienie Full Trust
- ustawienia rejestru
- pliki systemowe
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się o wymaganiach zaufania, uprawnieniach i ograniczeniach hostingu Aspose.Slides dla .NET, aby móc bezpiecznie wdrażać aplikacje przetwarzające PPT, PPTX i ODP na serwerach."
---
{{% alert color="primary" %}} 

Wszystkie komponenty Aspose .NET wymagają zestawu uprawnień Full Trust, ponieważ czasami muszą uzyskać dostęp do ustawień rejestru, plików systemowych oraz plików przechowywanych w innych lokalizacjach (poza wirtualnym katalogiem) w celu wykonania niektórych operacji (na przykład parsowania czcionek). Co więcej, komponenty Aspose .NET opierają się na podstawowych klasach systemowych .NET, które w wielu przypadkach wymagają zestawu uprawnień Full Trust. 

{{% /alert %}} 

Dostawcy usług internetowych, którzy hostują wiele aplikacji od różnych firm, najczęściej wymuszają poziom bezpieczeństwa Medium Trust. W przypadku .NET 2.0 taki poziom bezpieczeństwa wprowadza następujące ograniczenia: 

- OleDbPermission nie jest dostępne. Oznacza to, że nie możesz używać zarządzanego dostawcy danych OLE DB ADO.NET do dostępu do baz danych.
- EventLogPermission nie jest dostępne. Oznacza to, że nie możesz uzyskać dostępu do dziennika zdarzeń Windows.
- ReflectionPermission nie jest dostępne. Oznacza to, że nie możesz używać refleksji.
- RegistryPermission nie jest dostępne. Oznacza to, że nie możesz uzyskać dostępu do rejestru.
- WebPermission jest ograniczone. Oznacza to, że Twoja aplikacja może komunikować się tylko z adresem lub zakresem adresów, które zdefiniowałeś w elemencie <trust>.
- FileIOPermission jest ograniczone. Oznacza to, że możesz uzyskać dostęp tylko do plików w hierarchii wirtualnego katalogu Twojej aplikacji.

{{% alert color="primary" %}} 

Z powyższych powodów komponenty Aspose .NET mogą być używane wyłącznie na serwerach, które przyznają zestaw uprawnień Full Trust. 

{{% /alert %}}