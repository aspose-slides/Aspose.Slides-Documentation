---
title: Экспорт презентаций в XAML на C++
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/cpp/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- конвертация PowerPoint
- конвертация OpenDocument
- конвертация презентации
- PowerPoint в XAML
- OpenDocument в XAML
- презентация в XAML
- PPT в XAML
- PPTX в XAML
- ODP в XAML
- сохранить PPT как XAML
- сохранить PPTX как XAML
- сохранить ODP как XAML
- экспорт PPT в XAML
- экспорт PPTX в XAML
- экспорт ODP в XAML
- C++
- Aspose.Slides
description: "Конвертировать слайды PowerPoint и OpenDocument в XAML на C++ с помощью Aspose.Slides — быстрое решение без Office, сохраняющее макет неизменным."
---

## **Экспорт презентаций в XAML**

{{% alert color="primary" %}} 

В [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/) мы реализовали поддержку экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML. 

{{% /alert %}} 

## **О XAML**

XAML — это описательный язык программирования, который позволяет создавать или писать пользовательские интерфейсы для приложений, особенно для тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin Forms.  

XAML, являющийся языком на основе XML, представляет собой вариант Microsoft для описания графического интерфейса. Обычно вы будете работать с XAML‑файлами в дизайнере, но при необходимости можете писать и редактировать интерфейс вручную. 

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Этот код на C++ показывает, как экспортировать презентацию в XAML с настройками по умолчанию:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **Экспорт презентаций в XAML с пользовательскими параметрами**

Вы можете выбирать параметры из интерфейса [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options), которые управляют процессом экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML. 

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды вашей презентации при экспорте в XAML, передайте `true` методу [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). См. пример кода на C++: 
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **FAQ**

**Как обеспечить предсказуемый шрифт, если оригинальный шрифт недоступен на машине?**

Используйте [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) в [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — он служит резервным шрифтом, когда оригинальный отсутствует. Это помогает избежать неожиданной подстановки.

**Экспортированный XAML предназначен только для WPF или его можно использовать в других стеках XAML?**

XAML — это общий язык разметки UI, используемый в WPF, UWP и Xamarin.Forms. Экспорт ориентирован на совместимость со стеками Microsoft XAML; точное поведение и поддержка конкретных конструкций зависят от целевой платформы. Проверьте разметку в своей среде.

**Поддерживаются ли скрытые слайды и как можно отключить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Управлять этим можно через [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) в [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — оставьте его отключённым, если вам не требуется экспортировать скрытые слайды.