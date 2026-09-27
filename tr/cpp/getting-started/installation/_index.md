---
title: Kurulum
type: docs
weight: 70
url: /tr/cpp/installation/
keywords:
- Aspose.Slides yükle
- Aspose.Slides indir
- Aspose.Slides kullan
- Aspose.Slides kurulumu
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ı Windows'ta Visual Studio'da NuGet üzerinden, Linux'ta ise CMake ile ZIP paketinden kurun ve kurulumu ilk programla kontrol edin."
---
## **Genel Bakış**

Aspose.Slides for C++ iki biçimde dağıtılır:

| Form | Ne İçin Kullanılır | Nereden Alınır |
|---|---|---|
| NuGet paketleri: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64‑bit) ve [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32‑bit) | Windows üzerindeki Visual Studio C++ projeleri | NuGet |
| Windows, Linux ve macOS için ZIP paketleri | NuGet kullanılmadan yapılan derlemeler, örneğin CMake projeleri | [indirme sayfası](https://releases.aspose.com/slides/cpp/) |

Bu makale, Windows'ta Visual Studio’da NuGet paketinin nasıl kurulacağını ve Linux’da CMake ile ZIP paketinin nasıl kullanılacağını gösterir. Her iki yol da aynı kontrol ile sona erer: [Sunum Oluşturma](/slides/tr/cpp/create-presentation/) bölümündeki ilk örneği derleyip çalıştırın.

## **Windows**

Windows'ta, NuGet paketini bir Visual Studio C++ projesine ekleyin. Paket ayrıca bağımlılığı CodePorting.Translator.Cs2Cpp.Framework'ü kurar ve programınızın ihtiyaç duyduğu DLL'leri derleme çıktısı klasörüne kopyalar.

Derleme platformunuza göre paketi seçin: x64 için **Aspose.Slides.Cpp**, Win32 (x86) için **Aspose.Slides.Cpp.x86**. Aspose.Slides.Cpp paketi Win32 derlemesinde uygulanmaz; bu yüzden derleyici o platformda başlık dosyalarını bulamaz.

Ayrıca bir Windows ZIP paketi de [indirme sayfasından](https://releases.aspose.com/slides/cpp/) temin edilebilir.

### **Yöntem 1: NuGet Paket Yöneticisi ile Aspose.Slides'ı Yükleyin veya Güncelleyin**

1. Microsoft Visual Studio'yu açın.  
2. Bir C++ **Konsol Uygulaması** projesi oluşturun veya mevcut bir projeyi açın.  
3. **Solution Explorer**'da projeye sağ tıklayın ve **Manage NuGet Packages** seçeneğini seçin (ya da **Project** > **Manage NuGet Packages** menüsünü izleyin).  
4. **Browse** sekmesinde *Aspose.Slides.Cpp* paketini arayın.  
   ![NuGet Paket Yöneticisinde Aspose.Slides.Cpp Aranıyor](installation_1.png)  
5. **Aspose.Slides.Cpp** (32‑bit derleme için **Aspose.Slides.Cpp.x86**) paketine tıklayın ve ardından **Install** düğmesini seçin.  
   * Daha önce Aspose.Slides kurduysanız ve güncellemek istiyorsanız **Update** düğmesini tıklayın.

Paket indirildikten sonra projenize referans olarak eklenir.

### **Yöntem 2: Paket Yöneticisi Konsolu ile Aspose.Slides'ı Yükleyin veya Güncelleyin**

1. Microsoft Visual Studio'yu açın.  
2. Bir C++ **Konsol Uygulaması** projesi oluşturun veya mevcut bir projeyi açın.  
3. **Tools** > **NuGet Package Manager** > **Package Manager Console** menüsüne gidin.  
   ![Paket Yöneticisi Konsolu Açılıyor](installation_2.png)  
4. Aşağıdaki komutu çalıştırın:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   32‑bit (Win32) derleme için, bunun yerine x86 paketini kurun:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

   ![Install-Package komutu çalıştırılıyor](installation_3.png)

Kurulum tamamlandığında onay mesajları görüntülenir. Paket, [Aspose EULA](https://about.aspose.com/legal/eula) kapsamında dağıtılır.  
![Kurulum onay mesajları](installation_4.png)

Paketi güncellemek için Paket Yöneticisi Konsolu'nda `Update-Package Aspose.Slides.Cpp` (veya `Update-Package Aspose.Slides.Cpp.x86`) komutunu çalıştırın.

### **Kurulumu Kontrol Edin**

1. Projenin ana *.cpp* dosyasının (içinde `main` bulunan dosya) içeriğini, [Sunum Oluşturma](/slides/tr/cpp/create-presentation/) bölümündeki ilk örnekle değiştirin.  
2. Araç çubuğunda **x64** platformunu seçin, ya da **x86** paketini kurduysanız **x86** seçin.  
3. Programı derleyip çalıştırmak için **Ctrl+F5** tuşlarına basın.

Program, *hello.pptx* dosyasını proje klasörüne kaydeder; bu klasör Visual Studio programı çalıştırdığında varsayılan çalışma dizinidir.

## **Linux**

Linux'ta, CMake ile Linux ZIP paketini kullanın. Paket, Aspose.Slides kütüphanesini, bağımlılığı CodePorting.Translator.Cs2Cpp.Framework'ü ve her biri için bir CMake yapılandırma dosyasını içerir. Kütüphaneler, glibc 2.23 veya daha yeni bir sürümle çalışan x86_64 Linux için derlenmiştir.

1. Bir C++ derleyicisi, make, CMake, unzip ve Aspose.Slides kütüphanelerinin bağımlı olduğu fontconfig kütüphanesini kurun. Debian ve Ubuntu için:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. Bir proje klasörü oluşturun ve o klasöre geçin:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. [indirme sayfasından](https://releases.aspose.com/slides/cpp/) Linux ZIP (**Aspose.Slides for C++ Linux**) paketini proje klasörüne indirin ve *aspose-slides-cpp* alt klasörüne unzipleyin:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. Proje klasöründe aşağıdaki içeriğe sahip *CMakeLists.txt* adlı bir dosya oluşturun:

   ```cmake
   cmake_minimum_required(VERSION 3.13)
   project(HelloSlides CXX)

   set(CMAKE_CXX_STANDARD 14)
   set(CMAKE_CXX_STANDARD_REQUIRED ON)

   set(ASPOSE_SLIDES_DIR "${CMAKE_CURRENT_SOURCE_DIR}/aspose-slides-cpp")
   find_package(CodePorting.Translator.Cs2Cpp.Framework REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)
   find_package(Aspose.Slides.Cpp REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)

   add_executable(hello main.cpp)
   target_link_libraries(hello PRIVATE Aspose.Slides.Cpp)
   ```

   İki `find_package` çağrısı, unziplenen paketten CMake yapılandırma dosyalarını yükler. Çerçeve ilk olarak bulunur çünkü Aspose.Slides ona bağımlıdır. `Aspose.Slides.Cpp` hedefinin bağlanması, include klasörlerini ve iki kütüphaneyi derlemeye ekler.

5. [Sunum Oluşturma](/slides/tr/cpp/create-presentation/) bölümündeki ilk örneği proje klasörüne *main.cpp* olarak kaydedin.  
6. Programı derleyip çalıştırın:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

Program, *hello.pptx* dosyasını mevcut klasöre kaydeder. CMake, kütüphanelerin konumunu programda saklar; bu yüzden *aspose-slides-cpp* klasörü yerinde olduğu sürece `LD_LIBRARY_PATH` ayarlamanıza gerek yoktur.

Sunumlarınızda kullanılan yazı tipleri ya da uygun ikameleri, slaytları PDF ya da görsellere dönüştürürken metnin doğru şekilde render edilmesi için sistemde kurulu olmalıdır.

## **SSS**

**Ücretsiz bir sürüm veya deneme sınırlaması var mı?**

Evet. Lisans olmadan Aspose.Slides değerlendirme modunda çalışır: kaydettiği her slayda bir değerlendirme filigranı ekler ve sunumlardan okunan metni keser. Bu sınırlamaları kaldırmak için geçerli bir [lisans](/slides/tr/cpp/licensing/) uygulayın.

**Derleyici *DOM/Presentation.h* dosyasını açılamıyor diyor neden?**

Yüklediğiniz paket, derlediğiniz platformla eşleşmiyor. Aspose.Slides.Cpp yalnızca x64 derlemeleri için, Aspose.Slides.Cpp.x86 ise yalnızca Win32 derlemeleri için geçerlidir. Visual Studio'da doğru platformu seçin ya da diğer paketi kurun.