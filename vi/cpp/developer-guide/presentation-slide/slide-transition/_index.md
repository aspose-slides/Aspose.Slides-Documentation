---
title: Quản lý chuyển đổi slide trong bài thuyết trình bằng C++
linktitle: Chuyển đổi slide
type: docs
weight: 80
url: /vi/cpp/slide-transition/
keywords:
- chuyển đổi slide
- thêm chuyển đổi slide
- áp dụng chuyển đổi slide
- chuyển đổi slide nâng cao
- chuyển đổi Morph
- loại chuyển đổi
- hiệu ứng chuyển đổi
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Khám phá cách tùy chỉnh chuyển đổi slide trong Aspose.Slides cho C++, với hướng dẫn từng bước cho các bài thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Trong bài viết này giải thích cách quản lý chuyển đổi slide trong bài thuyết trình bằng Aspose.Slides. Nó chỉ ra cách áp dụng các loại chuyển đổi cho slide, cấu hình hành vi chuyển đổi như chuyển tiếp khi nhấp chuột hoặc sau một khoảng thời gian xác định, kiểm tra và tắt chuyển tiếp tự động, sử dụng chuyển đổi Morph và các loại của nó, và đặt các tùy chọn hiệu ứng chuyển đổi. Các ví dụ minh họa cách tải hoặc tạo một bài thuyết trình, sửa đổi cài đặt chuyển đổi cho các slide đã chọn, và lưu kết quả dưới dạng tệp PPTX. Bài viết cũng trả lời các câu hỏi thường gặp về tốc độ chuyển đổi, âm thanh chuyển đổi, áp dụng cùng một chuyển đổi cho nhiều slide, và kiểm tra chuyển đổi hiện đang được đặt trên một slide.

## **Thêm chuyển đổi slide**
Để dễ hiểu hơn, chúng tôi đã trình bày cách sử dụng Aspose.Slides for C++ để quản lý các chuyển đổi slide đơn giản. Các nhà phát triển không chỉ có thể áp dụng các hiệu ứng chuyển đổi slide khác nhau trên các slide, mà còn tùy chỉnh hành vi của các hiệu ứng này. Để tạo một hiệu ứng chuyển đổi slide đơn giản, làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Áp dụng một loại Slide Transition Type cho slide từ một trong các hiệu ứng chuyển đổi được Aspose.Slides for C++ cung cấp thông qua enum TransitionType.
3. Ghi tệp bài thuyết trình đã sửa đổi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Thêm chuyển đổi slide nâng cao**
Trong phần trên, chúng tôi chỉ áp dụng một hiệu ứng chuyển đổi đơn giản cho slide. Bây giờ, để làm cho hiệu ứng chuyển đổi đơn giản đó tốt hơn và được kiểm soát, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Áp dụng một Slide Transition Type cho slide từ một trong các hiệu ứng chuyển đổi do Aspose.Slides for C++ cung cấp.
3. Bạn cũng có thể đặt chuyển đổi để Tiến lên khi Nhấp chuột, sau một khoảng thời gian nhất định hoặc cả hai.
4. Nếu chuyển đổi slide được bật để Tiến lên khi Nhấp chuột, chuyển đổi sẽ chỉ tiến lên khi người dùng nhấp chuột. Hơn nữa, nếu thuộc tính Advance After Time được đặt, chuyển đổi sẽ tự động tiến lên sau thời gian đã chỉ định.
5. Ghi bài thuyết trình đã sửa đổi thành tệp bài thuyết trình.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Chuyển đổi Morph**
Aspose.Slides for C++ hiện hỗ trợ chuyển đổi Morph. Đây là loại chuyển đổi morph mới được giới thiệu trong PowerPoint 2019. Chuyển đổi Morph cho phép bạn tạo hoạt ảnh di chuyển mượt mà từ slide này sang slide tiếp theo. Bài viết này mô tả khái niệm và cách sử dụng chuyển đổi Morph. Để sử dụng chuyển đổi Morph hiệu quả, bạn cần có hai slide có ít nhất một đối tượng chung. Cách dễ nhất là sao chép slide và sau đó di chuyển đối tượng trên slide thứ hai đến vị trí khác.

Đoạn mã sau đây cho bạn thấy cách thêm một bản sao của slide có một số văn bản vào bài thuyết trình và đặt chuyển đổi loại morph cho slide thứ hai.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Các loại chuyển đổi Morph**
Enum mới Aspose.Slides.SlideShow.TransitionMorphType đã được thêm vào. Nó đại diện cho các loại chuyển đổi slide Morph khác nhau.

Enum TransitionMorphType có ba thành viên:

- ByObject: Chuyển đổi Morph sẽ được thực hiện bằng cách xem các hình dạng như những đối tượng không thể tách rời.
- ByWord: Chuyển đổi Morph sẽ được thực hiện bằng cách chuyển văn bản theo từ, nếu có thể.
- ByChar: Chuyển đổi Morph sẽ được thực hiện bằng cách chuyển văn bản theo ký tự, nếu có thể.

Đoạn mã sau đây cho bạn thấy cách đặt chuyển đổi morph cho slide và thay đổi loại morph:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Đặt hiệu ứng chuyển đổi**
Aspose.Slides for C++ hỗ trợ đặt các hiệu ứng chuyển đổi như, từ đen, từ trái, từ phải, v.v. Để đặt hiệu ứng chuyển đổi, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp Presentation.
- Lấy tham chiếu của slide.
- Đặt hiệu ứng chuyển đổi.
- Ghi bài thuyết trình dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã đặt các hiệu ứng chuyển đổi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát tốc độ phát của chuyển đổi slide không?**

Có. Đặt [speed](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) của chuyển đổi bằng cài đặt [TransitionSpeed](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/transitionspeed/) (ví dụ: slow/medium/fast).

**Tôi có thể đính kèm âm thanh vào chuyển đổi và đặt vòng lặp không?**

Có. Bạn có thể nhúng âm thanh cho chuyển đổi và kiểm soát hành vi thông qua các cài đặt như chế độ âm thanh và vòng lặp (ví dụ: [set_Sound](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), cùng với siêu dữ liệu như [set_SoundIsBuiltIn](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) và [set_SoundName](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Cấu hình loại chuyển đổi mong muốn trên cài đặt chuyển đổi của từng slide; chuyển đổi được lưu riêng cho mỗi slide, vì vậy áp dụng cùng một loại cho tất cả các slide sẽ cho kết quả nhất quán.

**Làm sao tôi có thể kiểm tra chuyển đổi nào hiện đang được đặt trên một slide?**

Kiểm tra [transition settings](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseslide/get_slideshowtransition/) của slide và đọc [transition type](https://reference.aspose.com/slides/vi/cpp/aspose.slides.slideshow/slideshowtransition/get_type/); giá trị đó cho bạn biết chính xác hiệu ứng nào đã được áp dụng.