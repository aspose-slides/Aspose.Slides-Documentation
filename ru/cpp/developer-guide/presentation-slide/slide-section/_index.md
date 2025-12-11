---
title: Управление разделами слайдов в презентациях с помощью C++
linktitle: Раздел слайдов
type: docs
weight: 100
url: /ru/cpp/slide-section/
keywords:
- создать раздел
- добавить раздел
- редактировать раздел
- изменить раздел
- имя раздела
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Оптимизируйте разделы слайдов в PowerPoint и OpenDocument с помощью Aspose.Slides для C++ — разделяйте, переименовывайте и переупорядочивайте для улучшения рабочих процессов PPTX и ODP."
---

С помощью Aspose.Slides для C++ вы можете организовать презентацию PowerPoint по разделам. Вы можете создавать разделы, содержащие определённые слайды. 

Вам может потребоваться создавать разделы и использовать их для организации или разделения слайдов в презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией совместно с другими людьми или командой — и вам нужно назначить определённые слайды коллеге или членам команды. 
- Когда вы имеете дело с презентацией, содержащей множество слайдов — и вам сложно управлять или редактировать её содержимое единовременно.

В идеале следует создать раздел, содержащий похожие слайды — у слайдов есть что‑то общее или они могут образовать группу по правилу — и дать разделу имя, описывающее слайды внутри него. 

## **Создание разделов в презентациях**

Чтобы добавить раздел, содержащий слайды в презентации, Aspose.Slides для C++ предоставляет метод AddSection, позволяющий указать имя создаваемого раздела и слайд, с которого начинается раздел. 

Этот пример кода показывает, как создать раздел в презентации на C++:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 будет завершён на newSlide2, а после него начнётся section2

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```


## **Изменение имён разделов**

После создания раздела в презентации PowerPoint вы можете решить изменить его имя. 

Этот пример кода показывает, как изменить имя раздела в презентации на C++ с использованием Aspose.Slides:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```


## **Часто задаваемые вопросы**

**Сохраняются ли разделы при сохранении в формате PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью скрыть раздел?**

Нет. Можно скрывать только отдельные слайды. У раздела как сущности нет состояния «скрыт».

**Можно ли быстро найти раздел по слайду и, наоборот, первый слайд раздела?**

Да. Раздел однозначно определяется своим начальным слайдом; по слайду можно определить, к какому разделу он принадлежит, а для раздела можно получить его первый слайд.