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
description: "Dowiedz się o wymaganiach zaufania, uprawnieniach i ograniczeniach hostingu Aspose.Slides dla .NET, aby móc bezpiecznie wdrażać aplikacje przetwarzające pliki PPT, PPTX i ODP na serwerach."
---
{{% alert color="info" %}} 

Wszystkie komponenty Aspose .NET wymagają zestawu uprawnień Full Trust, ponieważ czasami muszą uzyskać dostęp do ustawień rejestru, plików systemowych oraz plików przechowywanych w innych lokalizacjach (poza wirtualnym katalogiem) w ramach niektórych operacji (np. parsowanie czcionek). Ponadto komponenty Aspose .NET opierają się na podstawowych klasach systemu .NET, które w wielu przypadkach również wymagają zestawu uprawnień Full Trust. 

{{% /alert %}} 

Internet Service Providers, które hostują wiele aplikacji różnych firm, najczęściej wymuszają poziom bezpieczeństwa Medium Trust. W przypadku .NET 2.0 taki poziom bezpieczeństwa nakłada następujące ograniczenia: 

- OleDbPermission nie jest dostępne. Oznacza to, że nie możesz używać zarządzanego dostawcy danych OLE DB ADO.NET do dostępu do baz danych.
- EventLogPermission nie jest dostępne. Oznacza to, że nie możesz uzyskać dostępu do dziennika zdarzeń Windows.
- ReflectionPermission nie jest dostępne. Oznacza to, że nie możesz używać refleksji.
- RegistryPermission nie jest dostępne. Oznacza to, że nie możesz uzyskać dostępu do rejestru.
- WebPermission jest ograniczone. Oznacza to, że aplikacja może komunikować się tylko z adresem lub zakresem adresów określonym w elemencie <trust>.
- FileIOPermission jest ograniczone. Oznacza to, że możesz uzyskać dostęp wyłącznie do plików w hierarchii wirtualnego katalogu aplikacji.

{{% alert color="info" %}} 

Z powyższych powodów komponenty Aspose .NET mogą być używane wyłącznie na serwerach, które przyznają zestaw uprawnień Full Trust. 

{{% /alert %}}