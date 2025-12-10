---
title: Экспорт математических уравнений из презентаций на C++
linktitle: Экспорт уравнений
type: docs
weight: 30
url: /ru/cpp/exporting-math-equations/
keywords:
- экспорт математических уравнений
- MathML
- LaTeX
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Обеспечьте бесшовный экспорт математических уравнений из PowerPoint в MathML с помощью Aspose.Slides для C++ — сохраните форматирование и повысите совместимость."
---

## **Экспорт математических уравнений из презентаций**

Aspose.Slides for C++ позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе. 

{{% alert color="primary" %}} 
Вы можете экспортировать уравнения в MathML — популярный формат или стандарт для математических уравнений и похожего контента, используемого в вебе и многих приложениях. 
{{% /alert %}}

В то время как людям легко писать код для некоторых форматов уравнений, таких как LaTeX, им трудно писать код для MathML, поскольку последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, потому что его код находится в XML, поэтому MathML часто используется в качестве формата вывода и печати во многих сферах. 

Этот пример кода показывает, как экспортировать математическое уравнение из презентации в MathML:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        ->SetSuperscript(u"2")
        ->Join(u"+")
        ->Join(System::MakeObject<MathematicalText>(u"b")
                ->SetSuperscript(u"2"))
        ->Join(u"=")
        ->Join(System::MakeObject<MathematicalText>(u"c")
                ->SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```


## **Часто задаваемые вопросы**

**Что именно экспортируется в MathML — абзац или отдельный блок формулы?**

Вы можете экспортировать либо целый математический абзац ([MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)) , либо отдельный блок ([MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)) в MathML. Оба типа предоставляют метод для записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) и имеет [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) не являются экспортируемыми формулам.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или стандарт?**

Экспорт ориентирован на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, предназначенное для презентаций, которое широко применяется в различных приложениях и в вебе.

**Поддерживается ли экспорт формул, находящихся в таблицах, SmartArt, группах и т.п.?**

Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) (т.е. истинные формулы PowerPoint), они экспортируются. Если формула встроена как изображение, экспорт не производится.

**Изменяется ли оригинальная презентация при экспорте в MathML?**

Нет. Запись MathML является сериализацией содержимого формулы; она не изменяет файл презентации.